using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Query.Contracts.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext context;

        public ArticleQuery(BlogContext context)
        {
            this.context = context;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return context.Articles.Include(x => x.Category).Where(x => x.PublishDate <= DateTime.Now).Select(x =>
                new ArticleQueryModel
                {
                    Title = x.Title,
                    Picture = x.Picture,
                    Slug = x.Slug,
                    Description = x.Description,
                    PictureAlt = x.PictureAlt,
                    CategoryId = x.CategoryId,
                    PictureTitle = x.PictureTitle,
                    MetaDescription = x.MetaDescription,
                    CategorySlug = x.Category.Slug,
                    CanonicalAddress = x.CanonicalAddress,
                    CategoryName = x.Category.Name,
                    Keywords = x.Keywords,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription
                }).ToList();
        }
    }
}
