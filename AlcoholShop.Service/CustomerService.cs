using System;
using System.Collections.Generic;
using System.Linq;
using AlcoholShop.Models.BindingModels.Customer;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Customer;
using AutoMapper;

namespace AlcoholShop.Services
{
    public class CustomerService : Service
    {
        public Customer GetCurrentCustomer(string userName)
        {
            var user = Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            var customer = Context.Customers.FirstOrDefault(c => c.User.Id == user.Id);

            return customer;
        }

        public void AddProductInCart(int productId, Customer customer)
        {
            var wantedProduct = Context.Products.Find(productId);

            if (wantedProduct != null && wantedProduct.Amount > 0)
            {
                var product = Context.Purchases.FirstOrDefault(p => p.ProductId == wantedProduct.Id);

                bool exist;
                try
                {
                    exist = product.ProductId == wantedProduct.Id;
                }
                catch (NullReferenceException)
                {
                    exist = false;
                }

                if (exist)
                {
                    product.Quantity++;
                    product.TotalPrice = wantedProduct.Price * product.Quantity;
                }
                else
                {
                    var purch = new Purchase();
                    purch.Id++;
                    purch.CustomerId = customer.Id;
                    purch.ProductId = wantedProduct.Id;
                    purch.Name = wantedProduct.Name;
                    purch.Description = wantedProduct.Description;
                    purch.Quantity++;
                    purch.UnitPrice = wantedProduct.Price;
                    purch.TotalPrice = wantedProduct.Price;

                    customer.CustomerPurchases.Add(purch);
                }

                wantedProduct.Amount = wantedProduct.Amount - 1;
            }

            Context.SaveChanges();
        }

        public void RemoveProductFromCart(int productId, Customer customer)
        {
            var product = Context.Purchases.FirstOrDefault(p => p.Id == productId);
            var wantedProduct = Context.Products.Find(product.ProductId);
            wantedProduct.Amount += product.Quantity;
            Context.Purchases.Remove(product);
            
           
            Context.SaveChanges();
        }

        public ShoppingCartViewModel GetShoppingCardViewModel(string userName)
        {
            var currentUser = Context.Users.FirstOrDefault(user => user.UserName == userName);
            var vm = Mapper.Map<ApplicationUser, ShoppingCartViewModel>(currentUser);
            var currentCustomer =
                Context.Customers.FirstOrDefault(customer => customer.User.Id == currentUser.Id);
            vm.ProductsInCart =
                Mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchasesViewModel>>(currentCustomer.CustomerPurchases);

            return vm;
        }

        public EditCustomerDetailsViewModel GetEditCustomerDetailsViewModel(string userName)
        {
            var user =
                Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            var vm = Mapper.Map<ApplicationUser, EditCustomerDetailsViewModel>(user);

            return vm;
        }

        public void EditCustomerDetails(EditCustomerDetailsBindingModel bind, string currentUserName)
        {
            var user =
                Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == currentUserName);
            user.Name = bind.Name;
            user.Address = bind.Address;
            user.Postcode = bind.Postcode;
            user.PhoneNumber = bind.PhoneNumber;
            Context.SaveChanges();
        }
    }
}