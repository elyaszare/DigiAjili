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
                    "Product", new List<PermissionDto>
                    {
                        new(10, "ListProduct"),
                        new(11, "SearchProduct"),
                        new(12, "CreateProduct"),
                        new(13, "EditProduct")
                    }
                },
                {
                    "ProductCategory", new List<PermissionDto>
                    {
                        new(20, "ListProductCategories"),
                        new(21, "SearchProductCategories"),
                        new(22, "CreateProductCategory"),
                        new(23, "EditProductCategory")
                    }
                }
            };
        }
    }
}
