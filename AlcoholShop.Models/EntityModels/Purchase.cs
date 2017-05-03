using System.ComponentModel.DataAnnotations;

namespace AlcoholShop.Models.EntityModels
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}