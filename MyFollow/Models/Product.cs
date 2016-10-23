using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFollow.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("[https|http]+?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)")]
        [StringLength(256)]
        [DisplayName("Url")]
        public string Url { get; set; }
        [StringLength(600)]
        [DisplayName("Description")]
        public string Description { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<EndUser> Users { get; set; }
    }
}