using _01_Query.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public ProductViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }


        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetLastArrivals();
            return View(products);
        }
    }
}
