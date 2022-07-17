namespace InventoryManagement.Application.Contract.Inventory
{
    public class ReduceInventory
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public string Description { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }

        public ReduceInventory()
        {
        }

        public ReduceInventory(long productId, string description, long count, long orderId)
        {
            ProductId = productId;
            Description = description;
            Count = count;
            OrderId = orderId;
        }
    }
}