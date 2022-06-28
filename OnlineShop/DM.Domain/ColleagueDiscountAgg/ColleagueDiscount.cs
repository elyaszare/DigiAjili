using _0_Framework.Domain;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; set; }
        public bool IsRemoved { get; set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemoved = false;
        }

        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
