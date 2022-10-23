using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskCustomers.Models
{
    public class HomeViewModel
    {
        public List<Customer> Customers { get; set; }
        public Header Header { get; set; }
    }
}
