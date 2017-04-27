using Microsoft.Build.Framework;

namespace AlcoholShop.Models.ViewModels.Admin
{
    public class EditProductViewModel
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