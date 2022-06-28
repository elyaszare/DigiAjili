using System.Collections.Generic;

namespace _01_Query.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLastArrivals();
    }
}
