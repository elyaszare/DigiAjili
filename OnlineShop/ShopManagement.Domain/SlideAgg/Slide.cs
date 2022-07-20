//Slide Model

using _0_Framework.Domain;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BntText { get; private set; }
        public string Link { get; private set; }
        public bool IsRemoved { get; private set; }


        public Slide(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text,
            string link,
            string bntText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BntText = bntText;
            IsRemoved = false;
            Link = link;
        }


        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title,
            string text,
            string link,
            string bntText)
        {
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BntText = bntText;
            Link = link;
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