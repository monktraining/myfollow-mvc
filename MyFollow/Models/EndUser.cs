using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFollow.Models
{
    public class EndUser : UserBase
    {
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}