using AlcoholShop.Models.BindingModels.Admin;
using AlcoholShop.Models.ViewModels.Admin;

namespace AlcoholShop.Services.Interfaces
{
    public interface IAdminService
    {
        AdminPageViewModel GetAdminPage();
        void AddProduct(AddProductBindingModel bind);
        void DeleteProduct(string productName);
        EditProductViewModel GetEditProductViewModel(string productName);
        void EditProduct(EditProductBindingModel bind, string productName);
    }
}