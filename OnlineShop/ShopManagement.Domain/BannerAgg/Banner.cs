//Slide Model

using System;
using _0_Framework.Domain;

namespace ShopManagement.Domain.BannerAgg
{
    public class Banner : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string BntText { get; private set; }
        public string Link { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Banner(string picture, string pictureAlt, string pictureTitle, string heading, string title,
            string link,
            string bntText, DateTime startDate, DateTime endDate)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            BntText = bntText;
            IsRemoved = false;
            Link = link;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title,
            string link,
            string bntText, DateTime startDate, DateTime endDate)
        {
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            BntText = bntText;
            Link = link;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}