using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Root
    {
        public Header header { get; set; }
        public List<Customer> customers { get; set; }
    }
}
