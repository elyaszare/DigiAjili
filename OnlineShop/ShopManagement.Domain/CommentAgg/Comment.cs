using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; }
        public string Email { get; }
        public string Message { get; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long ProductId { get; }
        public Product Product { get; private set; }

        public Comment(string name, string email, string message, long productId)
        {
            Name = name;
            Email = email;
            Message = message;
            ProductId = productId;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
