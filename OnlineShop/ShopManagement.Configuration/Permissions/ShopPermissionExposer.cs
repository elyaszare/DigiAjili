using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new()
            {
                {
                    "Product",
                    new List<PermissionDto>
                    {
                        new(ShopPermissions.ListProducts, "ListProducts"),
                        new(ShopPermissions.SearchProducts, "SearchProducts"),
                        new(ShopPermissions.CreateProduct, "CreateProduct"),
                        new(ShopPermissions.EditProduct, "EditProduct")
                    }
                },
                {
                    "ProductCategory",
                    new List<PermissionDto>
                    {
                        new(ShopPermissions.SearchProductCategories, "SearchProductCategories"),
                        new(ShopPermissions.ListProductCategories, "ListProductCategories"),
                        new(ShopPermissions.CreateProductCategory, "CreateProductCategory"),
                        new(ShopPermissions.EditProductCategory, "EditProductCategory")
                    }
                }
            };
        }
    }
}
