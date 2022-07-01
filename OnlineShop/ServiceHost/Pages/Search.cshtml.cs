using System.Collections.Generic;
using _01_Query.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string SearchModelInput;

        public List<ProductQueryModel> Products;
        private readonly IProductQuery _productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }


        public void OnGet(string searchModel)
        {
            SearchModelInput = searchModel;
            Products = _productQuery.Search(searchModel);
        }
    }
}
