using System.Web.Mvc;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Customer;
using AlcoholShop.Services;

namespace AlcoholShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private CustomerService service;

        public CustomerController()
        {
            this.service = new CustomerService();
        }

        [HttpPost]
        [Route("addtocart")]
        public ActionResult AddToCart(int productId)
        {
            string userName = this.User.Identity.Name;
            Customer customer = this.service.GetCurrentCustomer(userName);
            this.service.AddProductInCart(productId, customer);
            return RedirectToAction("ShoppingCart");
        }

        public ActionResult ShoppingCart()
        {
            string userName = this.User.Identity.Name;
            ShoppingCartViewModel vm = this.service.GetShoppingCardViewModel(userName);

            return this.View(vm);
        }
    }
}