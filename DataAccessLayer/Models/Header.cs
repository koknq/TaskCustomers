using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Header
    {
        [Key]
        public string report_date { get; set; }
        public int total_number_customer_records { get; set; }
    }
}
