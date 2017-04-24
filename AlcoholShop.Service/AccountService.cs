using AlcoholShop.Models.EntityModels;

namespace AlcoholShop.Services
{
    public class AccountService : Service
    {
        public void CreateCustomer(ApplicationUser user)
        {
            Customer customer = new Customer();
            customer.User = user;
            this.Context.Customers.Add(customer);
        }
    }
}