using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlcoholShop.Web.Startup))]
namespace AlcoholShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
