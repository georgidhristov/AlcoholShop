using System.Web.Mvc;
using AlcoholShop.Models.BindingModels.Customer;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Customer;
using AlcoholShop.Services;

namespace AlcoholShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    [RoutePrefix("customer")]
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

        [HttpPost]
        [Route("removefromcart")]
        public ActionResult RemoveFromCart(int productId)
        {
            string userName = this.User.Identity.Name;
            Customer customer = this.service.GetCurrentCustomer(userName);
            this.service.RemoveProductFromCart(productId, customer);
            return RedirectToAction("ShoppingCart");
        }

        [Route("shoppingcart")]
        public ActionResult ShoppingCart()
        {
            string userName = this.User.Identity.Name;
            ShoppingCartViewModel vm = this.service.GetShoppingCardViewModel(userName);

            return this.View(vm);
        }

        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            EditCustomerDetailsViewModel vm = this.service.GetEditCustomerDetailsViewModel(userName);

            return this.View(vm);
        }

        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(EditCustomerDetailsBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.EditCustomerDetails(bind, currentUserName);
                return this.RedirectToAction("ShoppingCart");
            }

            string userName = this.User.Identity.Name;
            EditCustomerDetailsViewModel vm = this.service.GetEditCustomerDetailsViewModel(userName);

            return this.View(vm);
        }
    }
}