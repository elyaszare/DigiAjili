using System.Collections.Generic;
using _01_Query.Contracts.ArticleCategory;
using _01_Query.Contracts.ProductCategory;

namespace _01_Query
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
