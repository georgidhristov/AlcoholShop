using System.Collections.Generic;
using System.Web.Mvc;
using AlcoholShop.Models.ViewModels.Product;
using AlcoholShop.Services;

namespace AlcoholShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            service = new HomeService();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> vms = this.service.GetAllProducts();
            return View(vms);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}