﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlcoholShop.Models.EntityModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }
    }
}