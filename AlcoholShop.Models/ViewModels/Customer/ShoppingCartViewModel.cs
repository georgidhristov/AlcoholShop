using System;
using System.Collections.Generic;

namespace AlcoholShop.Models.ViewModels.Customer
{
    public class ShoppingCartViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public IEnumerable<CustomerProductViewModel> ProductsInCart { get; set; } 
    }
}