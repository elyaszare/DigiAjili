using System.Collections.Generic;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Infrastructure.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        public SelectList Roles;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        [NeedsPermission(AccountPermissions.ListAccounts)]
        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.GetRoles(), "Id", "Name");
            Accounts = _accountApplication.Search(searchModel);
        }

        [NeedsPermission(AccountPermissions.CreateAccount)]
        public IActionResult OnGetCreate()
        {
            var command = new RegisterAccount
            {
                Roles = _roleApplication.GetRoles()
            };
            return Partial("./Create", command);
        }

        [NeedsPermission(AccountPermissions.CreateAccount)]
        public JsonResult OnPostCreate(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            return new JsonResult(result);
        }

        [NeedsPermission(AccountPermissions.EditAccount)]
        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);

            return new JsonResult(result);
        }

        [NeedsPermission(AccountPermissions.EditAccount)]
        public IActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetails(id);
            account.Roles = _roleApplication.GetRoles();
            return Partial("Edit", account);
        }

        [NeedsPermission(AccountPermissions.ChangePassword)]
        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var result = _accountApplication.ChangePassword(command);

            return new JsonResult(result);
        }

        [NeedsPermission(AccountPermissions.ChangePassword)]
        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword {Id = id};
            return Partial("ChangePassword", command);
        }

        [NeedsPermission(AccountPermissions.Active)]
        public IActionResult OnGetActive(long id)
        {
            _accountApplication.Active(id);
            return RedirectToPage("/Index");
        }
    }
}
