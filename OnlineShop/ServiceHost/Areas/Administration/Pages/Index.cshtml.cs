using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        public long UserCount;
        public string TotalSale;
        public long OrderCounts;
        public long ProductCount;
        private readonly IAccountApplication _accountApplication;
        private readonly IOrderApplication _orderApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IAccountApplication accountApplication, IOrderApplication orderApplication,
            IProductApplication productApplication)
        {
            _accountApplication = accountApplication;
            _orderApplication = orderApplication;
            _productApplication = productApplication;
        }

        public void OnGet()
        {
            UserCount = _accountApplication.GetAccounts().Count;
            TotalSale = _orderApplication.GetTotalSale().ToMoney();
            OrderCounts = _orderApplication.GetOrderCounts();
            ProductCount = _productApplication.GetProducts().Count;
        }
    }
}
