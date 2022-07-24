using System.Collections.Generic;
using _01_Query.Contracts.Article;
using _01_Query.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        public List<ArticleQueryModel> Articles;

        public BlogModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet()
        {
            Articles = _articleQuery.GetArticles();
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
        }
    }
}
