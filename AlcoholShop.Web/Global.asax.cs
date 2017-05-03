using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AlcoholShop.Models.EntityModels;
using AlcoholShop.Models.ViewModels.Admin;
using AlcoholShop.Models.ViewModels.Customer;
using AlcoholShop.Models.ViewModels.Product;
using AutoMapper;

namespace AlcoholShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Product, ProductViewModel>();
                expression.CreateMap<ApplicationUser, ShoppingCartViewModel>(); 
                expression.CreateMap<Purchase, PurchasesViewModel>();
                expression.CreateMap<ApplicationUser, EditCustomerDetailsViewModel>();
                expression.CreateMap<Product, EditProductViewModel>();
            });
        }
    }
}
