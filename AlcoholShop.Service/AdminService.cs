using System.Collections.Generic;
using System.Linq;
using AlcoholShop.Models.BindingModels.Admin;
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

            page.Products = productVms;

            return page;
        }

        public void AddProduct(AddProductBindingModel bind)
        {
            Product product = new Product();
            product.Name = bind.Name;
            product.Description = bind.Description;
            product.Amount = bind.Amount;
            product.Price = bind.Price;
            product.ImagePath = "~/Resources/" + bind.ImagePath;

            this.Context.Products.Add(product);
            this.Context.SaveChanges();
        }

        public void DeleteProduct(string productName)
        {
            Product product =
                this.Context.Products.FirstOrDefault(p => p.Name == productName);

            this.Context.Products.Remove(product);
            this.Context.SaveChanges();
        }

        public EditProductViewModel GetEditProductViewModel(string productName)
        {
            Product product =
                this.Context.Products.FirstOrDefault(p => p.Name == productName);
            EditProductViewModel vm = Mapper.Map<Product, EditProductViewModel>(product);

            return vm;
        }

        public void EditProduct(EditProductBindingModel bind, string productName)
        {
            Product product =
                this.Context.Products.FirstOrDefault(p => p.Name == productName);
            product.Name = bind.Name;
            product.Description = bind.Description;
            product.Amount = bind.Amount;
            product.Price = bind.Price;
            if (bind.ImagePath != null)
                product.ImagePath = "~/Resources/" + bind.ImagePath;

            this.Context.SaveChanges();
        }
    }
}