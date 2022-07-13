using System.Collections.Generic;
using ShopManagement.Application.Contracts.Order;

namespace _01_Query.Contracts
{
    public interface ICartCalculateService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}
