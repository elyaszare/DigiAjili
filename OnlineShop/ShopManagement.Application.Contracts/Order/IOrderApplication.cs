using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart, OrderInfo orderInfo);
        double GetAmountBy(long id);
        double GetTotalSale();
        long GetOrderCounts();
        string PaymentSucceeded(long orderId, long refId);
        void Cancel(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetItems(long orderId);
        OrderViewModel GetInfoBy(long id);
    }
}
