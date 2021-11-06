using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Product;
        private readonly IProductApplication ProductApplication;
        public SelectList ProductCategories;
        private readonly IProductCategoryApplication ProductCategoryApplication;

        public IndexModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            ProductApplication = productApplication;
            ProductCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(ProductCategoryApplication.GetProductCategories(), "Id", "Name");
            Product = ProductApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = ProductApplication.Create(command);
            return new JsonResult(result);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = ProductApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = ProductApplication.GetDetails(id);
            return Partial("Edit", product);
        }
    }
}
