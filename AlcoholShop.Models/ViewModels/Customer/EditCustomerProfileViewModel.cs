using Microsoft.Build.Framework;

namespace AlcoholShop.Models.ViewModels.Customer
{
    public class EditCustomerProfileViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}