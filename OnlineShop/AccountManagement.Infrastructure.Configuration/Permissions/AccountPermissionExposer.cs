using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace AccountManagement.Infrastructure.Configuration.Permissions
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new()
            {
                {
                    "Account",
                    new List<PermissionDto>
                    {
                        new(AccountPermissions.ListAccounts, "ListAccounts"),
                        new(AccountPermissions.SearchAccounts, "SearchAccounts"),
                        new(AccountPermissions.CreateAccount, "CreateAccount"),
                        new(AccountPermissions.EditAccount, "EditAccount"),
                        new(AccountPermissions.ChangePassword, "ChangePassword"),
                        new(AccountPermissions.Active, "Active")
                    }
                },
                {
                    "Role",
                    new List<PermissionDto>
                    {
                        new(AccountPermissions.SearchRoles, "SearchRoles"),
                        new(AccountPermissions.ListRoles, "ListRoles"),
                        new(AccountPermissions.CreateRoles, "CreateRoles"),
                        new(AccountPermissions.EditRoles, "EditRoles")
                    }
                }
            };
        }
    }
}
