using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace DiscountManagement.Configuration.Permissions
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new()
            {
                {
                    "Discount",
                    new List<PermissionDto>
                    {
                        new(DiscountPermissions.ListDiscounts, "ListDiscounts"),
                        new(DiscountPermissions.SearchDiscounts, "SearchDiscounts"),
                        new(DiscountPermissions.CreateDiscount, "CreateDiscount"),
                        new(DiscountPermissions.EditDiscount, "EditDiscount"),
                        new(DiscountPermissions.Remove, "Remove"),
                        new(DiscountPermissions.Restore, "Restore")
                    }
                }
            };
        }
    }
}