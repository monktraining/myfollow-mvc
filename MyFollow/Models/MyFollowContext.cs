using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyFollow.Models
{
    public class MyFollowContext : IdentityDbContext<ApplicationUser>
    {
        public MyFollowContext()
        {
            
        }

        public static MyFollowContext Create()
        {
            return new MyFollowContext();
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}