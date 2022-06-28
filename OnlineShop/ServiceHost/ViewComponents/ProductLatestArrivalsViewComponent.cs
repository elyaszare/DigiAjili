using _01_Query.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductLatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductQuery productQuery;

        public ProductLatestArrivalsViewComponent(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = productQuery.GetLastArrivals();
            return View(products);
        }
    }
}
