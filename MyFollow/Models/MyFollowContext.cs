using System.Data.Entity;

namespace MyFollow.Models
{
    public class MyFollowContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}