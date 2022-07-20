using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Banner;
using ShopManagement.Domain.BannerAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class BannerRepository : RepositoryBase<long, Banner>, IBannerRepository
    {
        private readonly ShopContext _context;

        public BannerRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditBanner GetDetails(long id)
        {
            return _context.Banners.Select(x => new EditBanner
            {
                Id = x.Id,
                Heading = x.Heading,
                Title = x.Title,
                BtnText = x.BntText,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Link = x.Link,
                EndDate = x.EndDate.ToString(),
                StartDate = x.StartDate.ToString()
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<BannerViewModel> GetList()
        {
            return _context.Banners.Select(x => new BannerViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Title = x.Title,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
                EndDate = x.EndDate.ToFarsi(),
                StartDate = x.StartDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
