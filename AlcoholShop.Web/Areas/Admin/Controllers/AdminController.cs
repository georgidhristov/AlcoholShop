using System.Web.Mvc;
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

        [HttpGet]
        [Route("product/{id}/edit")] //***s
        public ActionResult EditProduct()
        {
            return this.View(); 
        }
    }
}