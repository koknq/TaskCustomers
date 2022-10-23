using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Phone
    {
        [Key]
        public int PhoneID { get; set; }
        [JsonProperty("Phone")]
        public string Value { get; set; }
        public int CustomerID { get; set; }
    }
}
