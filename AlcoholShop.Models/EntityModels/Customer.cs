using System.Collections.Generic;

namespace AlcoholShop.Models.EntityModels
{
    public class Customer
    {
        public Customer()
        {
              this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}