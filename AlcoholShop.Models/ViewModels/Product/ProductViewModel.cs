using System.ComponentModel.DataAnnotations;

namespace AlcoholShop.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        [Display(Name = "Price: ")]
        public decimal Price { get; set; }
       
    }
}