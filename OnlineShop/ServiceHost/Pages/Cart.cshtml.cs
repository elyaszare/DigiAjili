using System;
using System.Collections.Generic;
using System.Linq;
using _01_Query.Contracts.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems;
        public const string CookieName = "cart-items";
        private readonly IProductQuery _productQuery;

        public CartModel(IProductQuery productQuery)
        {
            CartItems = new List<CartItem>();
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            if (cartItems != null)
                foreach (var item in cartItems)
                    item.TotalItemPrice = item.UnitPrice * item.Count;

            CartItems = _productQuery.CheckInventoryStock(cartItems);
        }

        public IActionResult OnGetRemoveFromCartItem(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(itemToRemove);
            var options = new CookieOptions {Expires = DateTime.Now.AddDays(1)};
            var serializeResult = serializer.Serialize(cartItems);
            Response.Cookies.Append("cart-items", serializeResult);
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetGoToCheckOut()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            if (cartItems != null)
                foreach (var item in cartItems)
                    item.TotalItemPrice = item.UnitPrice * item.Count;

            CartItems = _productQuery.CheckInventoryStock(cartItems);
            if (CartItems.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");
            return RedirectToPage("CheckOut");
        }
    }
}