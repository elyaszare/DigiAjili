using System.Collections.Generic;

namespace _01_Query.Contracts.Banner
{
    public interface IBannerQuery
    {
        public List<BannerQueryModel> GetBanners();
    }
}
