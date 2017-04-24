using AlcoholShop.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlcoholShop.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AlcoholShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AlcoholShopContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manage.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Customer");
                manage.Create(role);
            }

            context.Products.AddOrUpdate(c => c.Name, new Product[]
            {
                new Product()
                {
                    Name = "Jack Daniel's",
                    Description = "Middle class whisky, 700ml",
                    Amount = 0,
                    Price = 35.50M
                },
                new Product()
                {
                    Name = "Red Label",
                    Description = "Middle class whisky, 700ml",
                    Amount = 30,
                    Price = 20.00M
                },
                new Product()
                {
                    Name = "Paddy",
                    Description = "Middle class whisky, 700ml",
                    Amount = 44,
                    Price = 27.00M
                },
                new Product()
                {
                    Name = "Dimple",
                    Description = "Top shelf whisky, 700ml",
                    Amount = 3,
                    Price = 50.98M
                },
                new Product()
                {
                    Name = "Vat69",
                    Description = "Low class whisky, 700ml",
                    Amount = 36,
                    Price = 11.99M
                }
            });
        }
    }
}
