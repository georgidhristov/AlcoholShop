using System.Data.Entity;
using AlcoholShop.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlcoholShop.Data
{
    public class AlcoholShopContext : IdentityDbContext<ApplicationUser>
    {
        public AlcoholShopContext()
            : base("data source = (LocalDb)\\MSSQLLocalDB; initial catalog = AlcoholShop; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public static AlcoholShopContext Create()
        {
            return new AlcoholShopContext();
        }
    }
}