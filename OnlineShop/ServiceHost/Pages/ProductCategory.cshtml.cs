using System.Collections.Generic;
using _01_Query.Contracts.Product;
using _01_Query.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IProductQuery _productQuery;
        public List<ProductQueryModel> LatestProducts;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery, IProductQuery productQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(id);
            LatestProducts = _productQuery.GetProductsBy(ProductCategory.Id);
        }
    }
}
