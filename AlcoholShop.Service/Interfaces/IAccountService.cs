using AlcoholShop.Models.EntityModels;

namespace AlcoholShop.Services.Interfaces
{
    public interface IAccountService
    {
        void CreateCustomer(ApplicationUser user);
    }
}