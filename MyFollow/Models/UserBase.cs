using System.ComponentModel.DataAnnotations;

namespace MyFollow.Models
{
    public abstract class UserBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]        
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}