using System;
using System.Collections.Generic;
using System.Linq;
using _01_Query.Contracts.Banner;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class BannerQuery : IBannerQuery
    {
        private readonly ShopContext _context;

        public BannerQuery(ShopContext context)
        {
            _context = context;
        }

        public List<BannerQueryModel> GetBanners()
        {
            return _context.Banners.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Where(x => !x.IsRemoved).Select(x => new BannerQueryModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    IsRemoved = x.IsRemoved,
                    BtnText = x.BntText,
                    Heading = x.Heading,
                    Link = x.Link,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Title = x.Title
                }).OrderByDescending(x => x.Id).Take(6).ToList();
        }
    }
}
