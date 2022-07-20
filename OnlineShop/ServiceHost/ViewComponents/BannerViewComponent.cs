using _01_Query.Contracts.Banner;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerQuery _bannerQuery;

        public BannerViewComponent(IBannerQuery bannerQuery)
        {
            _bannerQuery = bannerQuery;
        }

        public IViewComponentResult Invoke()
        {
            var banners = _bannerQuery.GetBanners();
            return View(banners);
        }
    }
}
