using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace InventoryManagement.Infrastructure.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new()
            {
                {
                    "Inventory", new List<PermissionDto>
                    {
                        new(50, "ListInventory"),
                        new(51, "SearchInventory"),
                        new(52, "CreateInventory"),
                        new(53, "EditInventory")
                    }
                }
            };
        }
    }
}
