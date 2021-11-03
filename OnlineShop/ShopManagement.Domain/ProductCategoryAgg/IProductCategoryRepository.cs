using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory.ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
