using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Address
    {
        public int CustomerID { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        [Key]
        public int AdressID { get; set; }
        [JsonProperty("Address")]
        public string Value { get; set; }
    }
}
