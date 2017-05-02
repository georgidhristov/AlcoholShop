using System.Web.Mvc;
using AlcoholShop.Models.BindingModels.Admin;
using AlcoholShop.Models.ViewModels.Admin;
using AlcoholShop.Services;

namespace AlcoholShop.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            AdminPageViewModel vm = service.GetAdminPage();
            return this.View(vm);
        }

        [HttpGet]
        [Route("product/add")]
        public ActionResult AddProduct()
        {
            return this.View();
        }

        [HttpPost]
        [Route("product/add")]
        public ActionResult AddProduct(AddProductBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddProduct(bind);
                return this.RedirectToAction("Index");
            }

            return this.View();
        }

        [HttpGet]
        [Route("product/{name}/delete")]
        public ActionResult DeleteProduct(string name)
        {
            this.service.DeleteProduct(name);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("product/{name}/edit")]
        public ActionResult EditProduct(string name)
        {
            EditProductViewModel vm = this.service.GetEditProductViewModel(name);
            return this.View(vm);
        }

        [HttpPost]
        [Route("product/{name}/edit")]
        public ActionResult EditProduct(EditProductBindingModel bind, string name)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditProduct(bind, name);
                return this.RedirectToAction("Index");
            }

            EditProductViewModel vm = this.service.GetEditProductViewModel(name);

            return this.View(vm);
        }
    }
}