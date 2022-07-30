using System.Collections.Generic;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> CustomerDiscounts;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public IndexModel(IProductApplication ProductApplication,
            ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = ProductApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }

        [NeedsPermission(DiscountPermissions.ListDiscounts)]
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }

        [NeedsPermission(DiscountPermissions.CreateDiscount)]
        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        [NeedsPermission(DiscountPermissions.CreateDiscount)]
        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        [NeedsPermission(DiscountPermissions.EditDiscount)]
        public IActionResult OnGetEdit(long id)
        {
            var customerDiscount = _customerDiscountApplication.GetDetails(id);
            customerDiscount.Products = _productApplication.GetProducts();
            return Partial("Edit", customerDiscount);
        }

        [NeedsPermission(DiscountPermissions.EditDiscount)]
        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
