namespace _01_Query.Contracts.Comment
{
    public class CommentQueryModel
    {
        public string ParentName;
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public long ParentId { get; set; }
    }
}