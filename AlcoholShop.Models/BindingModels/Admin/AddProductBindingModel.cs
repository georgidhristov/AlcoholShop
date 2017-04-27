using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace AlcoholShop.Models.BindingModels.Admin
{
    public class AddProductBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, MinLength(1)]
        public string ImagePath { get; set; }
    }
}