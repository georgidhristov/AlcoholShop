using Microsoft.Build.Framework;

namespace AlcoholShop.Models.BindingModels.Admin
{
    public class EditProductBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}