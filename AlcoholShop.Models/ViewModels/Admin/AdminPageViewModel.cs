using System.Collections.Generic;
using AlcoholShop.Models.ViewModels.Product;

namespace AlcoholShop.Models.ViewModels.Admin
{
    public class AdminPageViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}