using System.ComponentModel.DataAnnotations;

namespace MyFollow.Models
{
    public class Address
    {
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int PinCode { get; set; }
    }
}