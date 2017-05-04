using AlcoholShop.Models.EntityModels;
using AlcoholShop.Services.Interfaces;

namespace AlcoholShop.Services
{
    public class AccountService : Service, IAccountService
    {
        public void CreateCustomer(ApplicationUser user)
        {
            Customer customer = new Customer();
            ApplicationUser au = this.Context.Users.Find(user.Id);
            customer.User = au;
            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }
    }
}