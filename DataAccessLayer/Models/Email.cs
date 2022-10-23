using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Email
    {
        [Key]
        public int EmailID { get; set; }

        public int CustomerID { get; set; }
        [JsonProperty("Email")]
        public string Value { get; set; }
    }
}
