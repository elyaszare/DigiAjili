using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Query.Contracts.Product;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public ProductQueryModel GetDetails(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId, x.EndDate}).ToList();


            var product = _shopContext.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures)
                .Include(x => x.Comments)
                .Select(x =>
                    new ProductQueryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        PictureTitle = x.PictureTitle,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        Category = x.Category.Name,
                        Slug = x.Slug,
                        CategorySlug = x.Category.Slug,
                        Code = x.Code,
                        Description = x.Description,
                        Keywords = x.Keywords,
                        ShortDescription = x.ShortDescription,
                        MetaDescription = x.MetaDescription,
                        Pictures = MapProductPicture(x.ProductPictures),
                        Comments = MapComments(x.Comments)
                    }).FirstOrDefault(x => x.Slug == slug);


            if (product == null) return new ProductQueryModel();
            var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();

                var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                if (discount != null)
                {
                    var discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round(price * discountRate / 100);
                    product.PriceWithDiscount = (price - discountAmount).ToMoney();

                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                }
            }

            return product;
        }

        public static List<CommentQueryModel> MapComments(List<Comment> comments)
        {
            return comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message
                }).OrderByDescending(x => x.Id).ToList();
        }

        public static List<ProductPictureQueryModel> MapProductPicture(List<ProductPicture> pictures)
        {
            return pictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }

        public List<ProductQueryModel> GetLastArrivals()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId}).ToList();


            var products = _shopContext.Products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Category = x.Category.Name,
                Slug = x.Slug
            }).OrderByDescending(x => x.Id).Take(6).ToList();


            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();

                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round(price * discountRate / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return products;
        }

        public List<ProductQueryModel> Search(string searchModel)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId, x.EndDate}).ToList();


            var query = _shopContext.Products
                .Include(x => x.Category)
                .Select(x =>
                    new ProductQueryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        PictureTitle = x.PictureTitle,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        Slug = x.Slug,
                        ShortDescription = x.ShortDescription,
                        CategorySlug = x.Category.Slug
                    }).AsNoTracking();


            if (!string.IsNullOrWhiteSpace(searchModel))
                query = query.Where(x => x.Name.Contains(searchModel) || x.ShortDescription.Contains(searchModel));

            var products = query.OrderByDescending(x => x.Id).ToList();

            foreach (var category in query)
            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();

                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round(price * discountRate / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();

                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    }
                }
            }

            return products;
        }
    }
}
