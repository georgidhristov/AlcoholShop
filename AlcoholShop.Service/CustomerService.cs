using System.Linq;
using AlcoholShop.Models.EntityModels;

namespace AlcoholShop.Services
{
    public class CustomerService : Service
    {
        public Customer GetCurrentCustomer(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            Customer customer = this.Context.Customers.FirstOrDefault(c => c.User.Id == user.Id);

            return customer;
        }

        public void AddProductInCart(int productId, Customer customer)
        {
            Product wantedProduct = this.Context.Products.Find(productId);
            customer.Products.Add(wantedProduct);
            if (wantedProduct != null && wantedProduct.Amount > 0)
            {
                wantedProduct.Amount = wantedProduct.Amount - 1;
            }
            this.Context.SaveChanges();
        }
    }
}