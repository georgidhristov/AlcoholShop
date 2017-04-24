using System.Collections.Generic;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Product;
using AutoMapper;

namespace AlcoholShop.Services
{
    public class HomeService : Service
    {
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            IEnumerable<Product> products = Context.Products;
            IEnumerable<ProductViewModel> vms =
                Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return vms;
        }
    }
}