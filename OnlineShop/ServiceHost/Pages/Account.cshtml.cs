using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }
        [TempData] public string RegisterMessage { get; set; }
        [TempData] public string RegisterMessageSuccess { get; set; }
        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            //if (IsMessage) LoginMessage = "نام کاربر یا رمز عبور شما صحیح نمی باشد.";
        }

        public RedirectToPageResult OnPostLogin(Login command, IFormCollection form)
        {
            var reCaptcha = new ReCaptchaAccount();
            var captchaResult = reCaptcha.CheckReCaptcha(form);
            if (!captchaResult.IsSucceeded)
            {
                LoginMessage = captchaResult.Message;
                return RedirectToPage("/Account");
            }

            var result = _accountApplication.Login(command);
            if (result.IsSucceeded) return RedirectToPage("/Index");

            LoginMessage = result.Message;
            return RedirectToPage("Account");
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterAccount command, IFormCollection form)
        {
            var reCaptcha = new ReCaptchaAccount();
            var captchaResult = reCaptcha.CheckReCaptcha(form);
            if (!captchaResult.IsSucceeded)
            {
                RegisterMessage = captchaResult.Message;
                return RedirectToPage("/Account");
            }

            var result = _accountApplication.Register(command);

            if (result.IsSucceeded)
            {
                RegisterMessageSuccess = result.Message;
                return RedirectToPage("/Account");
            }

            RegisterMessage = result.Message;
            return RedirectToPage("/Account");
        }
    }
}
