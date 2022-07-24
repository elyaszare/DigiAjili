using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Query.Contracts.Article;
using _01_Query.Contracts.Comment;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            this.context = context;
            _commentContext = commentContext;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return context.Articles.Where(x => !x.IsRemoved).Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now).Select(x =>
                    new ArticleQueryModel
                    {
                        Title = x.Title,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        PublishDate = x.PublishDate.ToFarsi(),
                        ShortDescription = x.ShortDescription,
                        Slug = x.Slug,
                        IsRemoved = x.IsRemoved
                    }).AsEnumerable().OrderByDescending(x => x.Id).Take(6).ToList();
        }

        public List<ArticleQueryModel> GetArticles()
        {
            return context.Articles.Where(x => !x.IsRemoved).Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now).Select(x =>
                    new ArticleQueryModel
                    {
                        Title = x.Title,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        PublishDate = x.PublishDate.ToFarsi(),
                        ShortDescription = x.ShortDescription,
                        Slug = x.Slug,
                        IsRemoved = x.IsRemoved
                    }).AsEnumerable().OrderByDescending(x => x.Id).ToList();
        }

        public List<ArticleQueryModel> LatestArticlesBy(long categoryId)
        {
            return context.Articles
                .Where(x => x.CategoryId == categoryId)
                .Where(x => !x.IsRemoved)
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now).Select(x =>
                    new ArticleQueryModel
                    {
                        Title = x.Title,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        PublishDate = x.PublishDate.ToFarsi(),
                        ShortDescription = x.ShortDescription,
                        Slug = x.Slug,
                        IsRemoved = x.IsRemoved
                    }).ToList();
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = context.Articles
                .Where(x => !x.IsRemoved)
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    Slug = x.Slug,
                    CanonicalAddress = x.CanonicalAddress,
                    Description = x.Description,
                    IsRemoved = x.IsRemoved,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription
                }).FirstOrDefault(x => x.Slug == slug);

            if (article == null) return new ArticleQueryModel();
            if (!string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordList = article.Keywords.Split("،").ToList();


            var comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
                if (comment.ParentId > 0)
                    comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;

            article.Comments = comments;
            return article;
        }
    }
}
