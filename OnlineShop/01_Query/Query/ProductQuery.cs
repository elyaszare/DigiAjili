﻿using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Query.Contracts.Comment;
using _01_Query.Contracts.Product;
using CommentManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext,
            CommentContext commentContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
            _commentContext = commentContext;
        }

        public ProductQueryModel GetProductDetails(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId, x.EndDate}).ToList();


            var product = _shopContext.Products
                .Include(x => x.Category)
                .Include(x => x.ProductPictures)
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
                        IsRemoved = x.IsRemoved,
                        Keywords = x.Keywords,
                        ShortDescription = x.ShortDescription,
                        MetaDescription = x.MetaDescription,
                        Pictures = MapProductPicture(x.ProductPictures)
                    }).Where(x => !x.IsRemoved).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(product.Keywords))
                product.KeywordList = product.Keywords.Split("،").ToList();

            if (product == null) return new ProductQueryModel();
            var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                product.DoublePrice = price;
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

            product.Comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Product)
                .Where(x => x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message
                }).OrderByDescending(x => x.Id).ToList();

            return product;
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
                Slug = x.Slug,
                IsRemoved = x.IsRemoved
            }).Where(x => !x.IsRemoved).OrderByDescending(x => x.Id).Take(6).ToList();


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

        public List<ProductQueryModel> GetProductWithDiscount()
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
                Slug = x.Slug,
                IsRemoved = x.IsRemoved
            }).Where(x => !x.IsRemoved).OrderByDescending(x => x.Id).ToList();


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

            return products.Where(x => x.HasDiscount).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductQueryModel> GetProducts()
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
                Slug = x.Slug,
                IsRemoved = x.IsRemoved
            }).Where(x => !x.IsRemoved).OrderByDescending(x => x.Id).ToList();


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

        public List<ProductQueryModel> GetProductsBy(long categoryId)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId}).ToList();


            var products = _shopContext.Products
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    Category = x.Category.Name,
                    Slug = x.Slug,
                    IsRemoved = x.IsRemoved
                }).Where(x => !x.IsRemoved).OrderByDescending(x => x.Id).ToList();


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
                        CategorySlug = x.Category.Slug,
                        IsRemoved = x.IsRemoved
                    }).Where(x => !x.IsRemoved).AsNoTracking();


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

        public List<CartItem> CheckInventoryStock(List<CartItem> cartItems)
        {
            if (cartItems != null)
            {
                var inventory = _inventoryContext.Inventory.ToList();

                foreach (var cartItem in cartItems.Where(cartItem =>
                    inventory.Any(x => x.ProductId == cartItem.Id && x.InStock)))
                {
                    var itemInventory = inventory.Find(x => x.ProductId == cartItem.Id);
                    cartItem.IsInStock = itemInventory.CalculateInventoryStock() >= cartItem.Count;
                }
            }

            return cartItems;
        }
    }
}
