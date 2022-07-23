namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int ShowOrder { get; set; }
        public int ArticleCount { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}