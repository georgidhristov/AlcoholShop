using System.Collections.Generic;
using System.Linq;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Customer;
using AutoMapper;

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
            if (wantedProduct != null && wantedProduct.Amount > 0)
            {
                customer.Products.Add(wantedProduct);
                wantedProduct.Amount = wantedProduct.Amount - 1;
            }

            this.Context.SaveChanges();
        }

        public ShoppingCartViewModel GetShoppingCardViewModel(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
            ShoppingCartViewModel vm = Mapper.Map<ApplicationUser, ShoppingCartViewModel>(currentUser);
            Customer currentCustomer = this.Context.Customers.FirstOrDefault(customer => customer.User.Id == currentUser.Id);
            vm.ProductsInCart = Mapper.Map<IEnumerable<Product>, IEnumerable<CustomerProductViewModel>>(currentCustomer.Products);

            return vm;
        }
    }
}