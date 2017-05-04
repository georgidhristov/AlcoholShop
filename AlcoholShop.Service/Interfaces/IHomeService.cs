using System.Collections.Generic;
using AlcoholShop.Models.ViewModels.Product;

namespace AlcoholShop.Services.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
    }
}