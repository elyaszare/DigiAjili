using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        public long UserCount;
        public string TotalSale;
        public long OrderCounts;
        private readonly IAccountApplication _accountApplication;
        private readonly IOrderApplication _orderApplication;

        public IndexModel(IAccountApplication accountApplication, IOrderApplication orderApplication)
        {
            _accountApplication = accountApplication;
            _orderApplication = orderApplication;
        }

        public void OnGet()
        {
            UserCount = _accountApplication.GetAccounts().Count;
            TotalSale = _orderApplication.GetTotalSale().ToMoney();
            OrderCounts = _orderApplication.GetOrderCounts();
        }
    }
}
