using AlcoholShop.Models.BindingModels.Customer;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Customer;

namespace AlcoholShop.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCurrentCustomer(string userName);
        void AddProductInCart(int productId, Customer customer);
        void RemoveProductFromCart(int productId, Customer customer);
        ShoppingCartViewModel GetShoppingCardViewModel(string userName);
        EditCustomerProfileViewModel GetEditCustomerProfileViewModel(string userName);
        void EditCustomerProfile(EditCustomerProfileBindingModel bind, string currentUserName);
    }
}