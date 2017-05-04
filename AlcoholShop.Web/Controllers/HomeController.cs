using System.Collections.Generic;
using System.Web.Mvc;
using AlcoholShop.Models.ViewModels.Product;
using AlcoholShop.Services;
using AlcoholShop.Services.Interfaces;

namespace AlcoholShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> vms = this.service.GetAllProducts();
            return View(vms);
        }


        [AllowAnonymous]
        public ActionResult Contact()
        { 
            return View();
        }
    }
}