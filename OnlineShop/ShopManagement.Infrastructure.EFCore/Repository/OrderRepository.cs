using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : RepositoryBase<long, Order>, IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public OrderRepository(ShopContext shopContext, AccountContext accountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public List<OrderItemViewModel> GetItems(long orderId)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var order = _shopContext.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return new List<OrderItemViewModel>();

            var items = order.Items.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in items) item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            return items;
        }

        public double GetTotalSale()
        {
            var orders = _shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                IsPaid = x.IsPaid,
                PayAmount = x.PayAmount
            }).AsEnumerable().Where(x => x.IsPaid).OrderByDescending(x => x.Id).ToList();

            var Sale = orders.Sum(order => order.PayAmount);

            return Sale;
        }

        public long GetOrderCounts()
        {
            return _shopContext.Orders.Where(x => x.IsPaid).ToList().Count();
        }

        public OrderViewModel GetInfoBy(long id)
        {
            var accountId = _shopContext.Orders
                .Select(x => new {x.AccountId, x.Id})
                .ToList()
                .FirstOrDefault(x => x.Id == id)?.AccountId;

            var account = _accountContext.Accounts
                .Select(x => new {x.Id, x.Fullname})
                .ToList()
                .FirstOrDefault(x => x.Id == accountId);

            var query = _shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Address = x.Address,
                Mobile = x.Mobile,
                Postalcode = x.Postalcode,
                DiscountAmount = x.DiscountAmount,
                IsCanceled = x.IsCanceled,
                IsPaid = x.IsPaid,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi(),
                AccountFullName = account.Fullname
            }).FirstOrDefault(x => x.Id == id);
            return query;
        }


        public double GetAmountBy(long id)
        {
            var amount = _shopContext.Orders.Select(x => new {x.PayAmount, x.Id}).FirstOrDefault(x=>x.Id==id);
            if (amount != null)
                return amount.PayAmount;

            return 0;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var accounts = _accountContext.Accounts.Select(x => new {x.Id, x.Fullname}).ToList();
            var query = _shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Address = x.Address,
                Mobile = x.Mobile,
                Postalcode = x.Postalcode,
                DiscountAmount = x.DiscountAmount,
                IsCanceled = x.IsCanceled,
                IsPaid = x.IsPaid,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi()
            });

            query = query.Where(x => x.IsCanceled == searchModel.IsCanceled);

            if (searchModel.AccountId > 0) query = query.Where(x => x.AccountId == searchModel.AccountId);

            if (!string.IsNullOrWhiteSpace(searchModel.IssueTrackingNo))
                query = query.Where(x => x.IssueTrackingNo == searchModel.IssueTrackingNo);

            var orders = query.OrderByDescending(x => x.Id).ToList();
            foreach (var order in orders)
                order.AccountFullName = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.Fullname;

            return orders;
        }
    }
}
