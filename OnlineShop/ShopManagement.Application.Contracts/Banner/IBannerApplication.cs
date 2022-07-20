using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Banner
{
    public interface IBannerApplication
    {
        OperationResult Create(CreateBanner command);
        OperationResult Edit(EditBanner command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditBanner GetDetails(long id);
        List<BannerViewModel> GetList();
    }
}
