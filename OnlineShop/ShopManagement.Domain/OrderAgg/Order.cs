using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBase
    {
        public string Address { get; }
        public string Mobile { get; }
        public string Postalcode { get; }
        public long AccountId { get; }
        public double TotalAmount { get; }
        public double DiscountAmount { get; }
        public double PayAmount { get; }
        public bool IsPaid { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }
        public List<OrderItem> Items { get; }

        public Order(long accountId, double totalAmount, double discountAmount, double payAmount, string address,
            string mobile, string postalcode)
        {
            AccountId = accountId;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            Address = address;
            Mobile = mobile;
            Postalcode = postalcode;
            IsCanceled = false;
            IsPaid = false;
            RefId = 0;
            Items = new List<OrderItem>();
        }

        public void PaymentSucceeded(long refId)
        {
            IsPaid = true;

            if (refId != 0)
                RefId = refId;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }

        public void Add(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
