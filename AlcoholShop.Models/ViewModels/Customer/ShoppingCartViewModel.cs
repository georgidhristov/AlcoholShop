﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlcoholShop.Models.ViewModels.Customer
{
    public class ShoppingCartViewModel
    {

        public string Name { get; set; }

        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public IEnumerable<PurchasesViewModel> ProductsInCart { get; set; } 
    }
}