﻿//Product Model 
//Product Property

using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsRemoved { get; set; }
        public ProductCategory Category { get; set; }
        public List<ProductPicture> ProductPictures { get; set; }

        public Product(string name, string code, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, long categoryId, string keywords,
            string metaDescription, string slug)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Keywords = keywords;
            IsRemoved = false;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string code, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, long categoryId, string keywords,
            string metaDescription, string slug)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
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
