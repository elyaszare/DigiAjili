using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication ProductCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            ProductCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = ProductCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = ProductCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = ProductCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var producategory = ProductCategoryApplication.GetDetail(id);
            return Partial("Edit", producategory);
        }
    }
}
