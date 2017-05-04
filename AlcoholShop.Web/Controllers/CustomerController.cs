using System.Web.Mvc;
using AlcoholShop.Models.BindingModels.Customer;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Customer;
using AlcoholShop.Services;
using AlcoholShop.Services.Interfaces;

namespace AlcoholShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    [RoutePrefix("customer")]
    public class CustomerController : Controller
    {
        private ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
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

        [HttpPost]
        [Route("removefromcart")]
        public ActionResult RemoveFromCart(int productId)
        {
            string userName = this.User.Identity.Name;
            Customer customer = this.service.GetCurrentCustomer(userName);
            this.service.RemoveProductFromCart(productId, customer);
            return RedirectToAction("ShoppingCart");
        }

        [HttpGet]
        [Route("shoppingcart")]
        public ActionResult ShoppingCart()
        {
            string userName = this.User.Identity.Name;
            ShoppingCartViewModel vm = this.service.GetShoppingCardViewModel(userName);

            return this.View(vm);
        }


        [HttpGet]
        [Route("editprofile")]
        public ActionResult EditProfile()
        {
            string userName = this.User.Identity.Name;
            EditCustomerProfileViewModel vm = this.service.GetEditCustomerProfileViewModel(userName);

            return this.View(vm);
        }

        [HttpPost]
        [Route("editprofile")]
        public ActionResult EditProfile(EditCustomerProfileBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.EditCustomerProfile(bind, currentUserName);
                return this.RedirectToAction("ShoppingCart");
            }

            string userName = this.User.Identity.Name;
            EditCustomerProfileViewModel vm = this.service.GetEditCustomerProfileViewModel(userName);

            return this.View(vm);
        }
    }
}