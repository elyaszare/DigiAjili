using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext context;

        public SlideRepository(ShopContext context) : base(context)
        {
            this.context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                Heading = x.Heading,
                Picture = x.Picture,
                Title = x.Title,
                BtnText = x.BntText,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                Heading = x.Heading,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToString()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
