using System.Collections.Generic;
using _01_Query.Contracts.Article;

namespace _01_Query.Contracts.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public int ShowOrder { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public List<string> KeywordList { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public long ArticlesCounts { get; set; }
        public bool IsRemoved { get; set; }
        public List<ArticleQueryModel> Articles { get; set; }
    }
}
