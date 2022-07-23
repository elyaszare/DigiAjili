using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ActiveAccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ActiveAccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet(string activeCode)
        {
            var result = _accountApplication.Active(activeCode);
            if (result.IsSucceeded)
            {
                IsSuccess = true;
                Message = "حساب کاربری شما فعال شد. می توانید با استفاده از لینک زیر وارد حساب کاربری خود شوید.";
            }
            else
            {
                IsSuccess = false;
                Message = result.Message;
            }
        }
    }
}




