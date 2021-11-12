using _01_Query.Contracts.Slides;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Query.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext context;

        public SlideQuery(ShopContext context)
        {
            this.context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return context.Slides.Where(x => x.IsRemoved == false).Select(x => new SlideQueryModel
            {
                Text = x.Text,
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
                BntText = x.BntText,
                Heading = x.Heading,
                Link = x.Link,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title
            }).ToList();

        }
    }
}
