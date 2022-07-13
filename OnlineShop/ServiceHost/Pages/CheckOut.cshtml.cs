using System.Collections.Generic;
using _01_Query.Contracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public Cart Cart;
        public const string CookieName = "cart-items";
        private readonly ICartCalculateService _cartCalculateService;

        public CheckOutModel(ICartCalculateService cartCalculateService)
        {
            _cartCalculateService = cartCalculateService;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            if (cartItems != null)
                foreach (var item in cartItems)
                    item.CalculateTotalItemPrice();

            Cart = _cartCalculateService.ComputeCart(cartItems);
        }
    }
}
