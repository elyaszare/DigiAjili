

namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //Product
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;

        //Order
        public const int ListOrder = 90;
        public const int SearchOrder = 91;
        public const int Confirm = 92;
        public const int Cancel = 93;
        public const int GetItems = 94;
        public const int GetInfo = 95;

        //ProductCategory
        public const int ListProductCategories = 20;
        public const int SearchProductCategories = 21;
        public const int CreateProductCategory = 22;
        public const int EditProductCategory = 23;
    }
}