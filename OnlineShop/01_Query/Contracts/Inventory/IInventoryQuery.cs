using InventoryManagement.Application.Contract.Inventory;

namespace _01_Query.Contracts.Inventory
{
    public interface IInventoryQuery
    {
        StockStatus CheckStock(IsInStock command);
    }
}
