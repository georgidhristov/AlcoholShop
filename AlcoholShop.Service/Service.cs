using AlcoholShop.Data;

namespace AlcoholShop.Services
{
    public abstract class Service
    {
        protected Service()
        {
            this.Context = new AlcoholShopContext();
        }

        protected AlcoholShopContext Context { get; }
    }
}