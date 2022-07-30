using System.Collections.Generic;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Infrastructure.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<RoleViewModel> Roles;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        [NeedsPermission(AccountPermissions.ListRoles)]
        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = _roleApplication.GetRoles();
        }
    }
}
