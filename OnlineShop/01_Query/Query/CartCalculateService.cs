using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using _01_Query.Contracts;
using DiscountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts.Order;

namespace _01_Query.Query
{
    public class CartCalculateService : ICartCalculateService
    {
        private readonly DiscountContext _discountContext;
        private readonly IAuthHelper _authHelper;
        public CartCalculateService(DiscountContext discountContext, IAuthHelper authHelper)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();

            var colleagueDiscounts = _discountContext.ColleagueDiscounts
                .Where(x => !x.IsRemoved)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var customerDiscounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            //Get Account Role 
            var currentAccountRole = _authHelper.CurrentAccountRole();

            foreach (var cartItem in cartItems)
            {
                if (currentAccountRole == Roles.ColleagueUser)
                {
                    var colleagueDiscount = colleagueDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (colleagueDiscount != null)
                        cartItem.DiscountRate = colleagueDiscount.DiscountRate;

                    var customerDiscount = customerDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (customerDiscount != null)
                        cartItem.DiscountRate = customerDiscount.DiscountRate;
                }
                else
                {
                    var customerDiscount = customerDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (customerDiscount != null)
                        cartItem.DiscountRate = customerDiscount.DiscountRate;
                }
                cartItem.DiscountAmount = ((cartItem.TotalItemPrice * cartItem.DiscountRate) / 100);
                cartItem.ItemPayAmount = cartItem.TotalItemPrice - cartItem.DiscountAmount;
                cart.Add(cartItem);
            }
            return cart;
        }
    }
}