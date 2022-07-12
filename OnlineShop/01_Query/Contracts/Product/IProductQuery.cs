﻿using System.Collections.Generic;
using ShopManagement.Application.Contracts.Order;

namespace _01_Query.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> GetLastArrivals();
        List<ProductQueryModel> Search(string searchModel);
        List<CartItem> CheckInventoryStock(List<CartItem> cartItems);
    }
}
