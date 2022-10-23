using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TaskCustomers.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net.Mail;

namespace TaskCustomers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            DbContextFactory dbContextFactory = new DbContextFactory();
            _unitOfWork = new UnitOfWork(dbContextFactory.CreateDbContext(null));
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Customers = _unitOfWork.CustomerManager.GetAll().ToList();

            model.Customers.ForEach(customer => customer.Emails = _unitOfWork.EmailManager.GetAll().Where(x => x.CustomerID == customer.CustomerID).ToList());
            model.Customers.ForEach(customer => customer.Phones = _unitOfWork.PhoneManager.GetAll().Where(x => x.CustomerID == customer.CustomerID).ToList());

            model.Customers.ForEach(customer => customer.Addresses = _unitOfWork.AdressManager.GetAll().Where(x => x.CustomerID == customer.CustomerID).ToList());
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            try
            {
                if (file == null)
                {
                    ViewBag.Message = "Invalid file!";
                    return View();
                }
                if(file.Length == 0)
                {
                    ViewBag.Message = "Invalid file!";
                    return View();
                }
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Entry", _FileName);
                using (var stream = System.IO.File.Create(_path))
                {
                    file.CopyTo(stream);
                }

                StreamReader r = new StreamReader(_path);
                string json = r.ReadToEnd();
                var list = JsonConvert.DeserializeObject<Root>(json);
                var head = JsonConvert.DeserializeObject<Root>(json);
                Header header = head.header;
                List<Email> validEmails = new List<Email>();
                foreach (Customer customer in list.customers)
                {
                    foreach(Email email in customer.Emails)
                    {
                        if(IsValidEmail(email.Value))
                        {
                            validEmails.Add(email);
                        }
                    }
                    if (list.customers.Count() != header.total_number_customer_records)
                    {
                        MoveToErrorFolder(file, _FileName);
                        ViewBag.Message = "File upload failed!! Number of customers is different than the number_customer_records!!";
                        return View();
                    }
                    else if (string.IsNullOrEmpty(customer.EGN))
                    {
                        MoveToErrorFolder(file, _FileName);
                        ViewBag.Message = "File upload failed!! There is missing EGN!!";
                        return View();
                    }
                    else if (validEmails.Count() < customer.Emails.Count())
                    {
                        MoveToErrorFolder(file, _FileName);
                        ViewBag.Message = "File upload failed!! There is invalid email!!";
                        return View();
                    }
                    else
                    {
                        validEmails.Clear();
                        _unitOfWork.CustomerManager.Add(customer);
                    }
                    
                }
                MoveToSuccessFolder(file, _FileName);
                _unitOfWork.SaveChanges();
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        private void MoveToErrorFolder(IFormFile file, string _FileName)
        {
            string _pathError = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Error", _FileName);
            using var stream = System.IO.File.Create(_pathError);
            file.CopyTo(stream);
        }

        private void MoveToSuccessFolder(IFormFile file, string _FileName)
        {
            string _pathSuccess = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Success", _FileName);
            using var stream = System.IO.File.Create(_pathSuccess);
            file.CopyTo(stream);
        }
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
