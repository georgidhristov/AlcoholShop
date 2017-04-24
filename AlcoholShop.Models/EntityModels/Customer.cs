namespace AlcoholShop.Models.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}