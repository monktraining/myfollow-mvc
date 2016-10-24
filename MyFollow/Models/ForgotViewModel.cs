using System.ComponentModel.DataAnnotations;

namespace MyFollow.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}