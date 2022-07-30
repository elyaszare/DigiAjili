using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_Query.Contracts;
using _01_Query.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        public const string CookieName = "cart-items";
        private readonly IAuthHelper _authHelper;
        private readonly ICartCalculateService _cartCalculateService;
        private readonly ICartService _cartService;
        private readonly IOrderApplication _orderApplication;
        private readonly IProductQuery _productQuery;
        private readonly IZarinPalFactory _zarinPalFactory;
        public Cart Cart;

        public CheckOutModel(ICartCalculateService cartCalculateService, ICartService cartService,
            IProductQuery productQuery, IOrderApplication orderApplication, IZarinPalFactory zarinPalFactory,
            IAuthHelper authHelper)
        {
            _cartCalculateService = cartCalculateService;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderApplication = orderApplication;
            _zarinPalFactory = zarinPalFactory;
            _authHelper = authHelper;
            Cart = new Cart();
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
            _cartService.Set(Cart);
        }

        public IActionResult OnPostPay(OrderInfo orderInfo)
        {
            var cart = _cartService.Get();
            var result = _productQuery.CheckInventoryStock(cart.Items);
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");
            var accountUserName = _authHelper.CurrentAccountInfo().Username;
            var accountMobile = _authHelper.CurrentAccountInfo().Mobile;
            var orderId = _orderApplication.PlaceOrder(cart, orderInfo);

            var paymentResponse = _zarinPalFactory.CreatePaymentRequest(cart.PayAmount.ToString(), accountMobile,
                accountUserName, "", orderId);

            return Redirect($"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long old)
        {
            var orderAmount = _orderApplication.GetAmountBy(old);
            var verificationResponse =
                _zarinPalFactory.CreateVerificationRequest(authority,
                    orderAmount.ToString(CultureInfo.InvariantCulture));

            var result = new PaymentResult();
            if (status == "OK" && verificationResponse.Status == 100)
            {
                var issueTrackingNumber = _orderApplication.PaymentSucceeded(old, verificationResponse.RefID);
                Response.Cookies.Delete("cart-items");
                result = result.Succeeded("پرداخت با موفقیت انجام شد", issueTrackingNumber);
                return RedirectToPage("/PaymentResult", result);
            }

            result = result.Failed(
                "عملیات پرداخت با شکست مواجه شد، در صورت کسر از حساب شما مبلغ تا 48 ساعت آینده به حساب شما واریز خواهد شد.");
            return RedirectToPage("/PaymentResult", result);
        }
    }
}