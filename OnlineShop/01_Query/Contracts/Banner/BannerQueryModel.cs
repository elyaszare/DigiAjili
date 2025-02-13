﻿namespace _01_Query.Contracts.Banner
{
    public class BannerQueryModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string BtnText { get; set; }
        public bool IsRemoved { get; set; }
        public string Link { get; set; }
    }
}
