using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlcoholShop.Models.EntityModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Purchase> CustomerPurchases { get; set; }
        
    }
}