using System.Collections.Generic;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public List<ArticleViewModel> Articles;
        public ArticleSearchModel SearchModel;
        public SelectList ArticleCategories;

        public IndexModel(IArticleApplication articleApplication,
            IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");

            Articles = _articleApplication.Search(searchModel);
        }

        //public IActionResult OnGetCreate()
        //{
        //    return Partial("./Create", new CreateArticleCategory());
        //}

        //public JsonResult OnPostCreate(CreateArticleCategory command)
        //{
        //    var result = _articleApplication.Create(command);
        //    return new JsonResult(result);
        //}

        //public JsonResult OnPostEdit(EditArticleCategory command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //    }

        //    var result = _articleApplication.Edit(command);
        //    return new JsonResult(result);
        //}

        //public IActionResult OnGetEdit(long id)
        //{
        //    var articleCategory = _articleApplication.GetProductDetails(id);
        //    return Partial("Edit", articleCategory);
        //}
    }
}