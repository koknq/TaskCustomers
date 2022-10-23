using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public virtual List<Email> Emails { get; set; }
        public virtual List<Phone> Phones { get; set; }
        public string DateOfBirth { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
