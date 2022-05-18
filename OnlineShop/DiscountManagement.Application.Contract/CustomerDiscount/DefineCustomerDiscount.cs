
using System.Collections.Generic;
using ShopManagement.Application.Contracts.Product;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }
        public long DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
