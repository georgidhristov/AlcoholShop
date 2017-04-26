using System.Collections.Generic;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Admin;
using AlcoholShop.Models.ViewModels.Product;
using AutoMapper;

namespace AlcoholShop.Services
{
    public class AdminService : Service
    {
        public AdminPageViewModel GetAdminPage()
        {
            AdminPageViewModel page = new AdminPageViewModel();
            IEnumerable<Product> products = this.Context.Products;

            IEnumerable<ProductViewModel> productVms =
                Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            page.products = productVms;

            return page;
        }
    }
}