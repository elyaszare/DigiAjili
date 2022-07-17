﻿using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Order;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<long, Order>
    {
        List<OrderItemViewModel> GetItems(long orderId);
        double GetAmountBy(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    }
}
