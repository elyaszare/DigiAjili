using System;
using _0_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime PublishDate { get; set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public bool IsRemoved { get; set; }
        public ArticleCategory Category { get; set; }

        public Article(string title, string shortDescription, string description, string picture, string pictureAlt,
            string pictureTitle, DateTime publishDate, string slug, string metaDescription, string keywords,
            string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            IsRemoved = false;
            CategoryId = categoryId;
        }

        public void Edit(string title, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate,
            string slug, string metaDescription, string keyWords, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keyWords;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
