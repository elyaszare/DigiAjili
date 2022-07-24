using System.Collections.Generic;
using _01_Query.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        public List<ProductQueryModel> Products;
        public List<ProductQueryModel> LatestProducts;

        public ProductsModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            Products = _productQuery.GetProducts();
            LatestProducts = _productQuery.GetLastArrivals();
        }
    }
}
