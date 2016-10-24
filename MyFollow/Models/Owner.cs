using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyFollow.Models
{
    public class Owner : UserBase
    {
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Range(1800,2016)]
        [Required]
        public int FoundedIn { get; set; }
        [Required]
        [RegularExpression("[https|http]+?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)")]
        [StringLength(256)]
        public string WebsiteUrl { get; set; }
        [Required]
        [RegularExpression("[https|http]+?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)")]
        [StringLength(256)]
        public string FacebookPageUrl { get; set; }
        [Required]
        [StringLength(50)]
        public string TwitterHandler { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}