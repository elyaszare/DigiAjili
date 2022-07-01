using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _context;

        public CommentRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _context.Comments
                .Include(x => x.Product)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    ProductId = x.ProductId,
                    IsConfirmed = x.IsConfirmed,
                    IsCanceled = x.IsCanceled,
                    Message = x.Message,
                    ProductName = x.Product.Name,
                    CommentDate = x.CreationDate.ToFarsi()
                });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));


            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<CommentViewModel> GetComments()
        {
            return _context.Comments.Include(x => x.Product).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                ProductId = x.ProductId,
                IsConfirmed = x.IsConfirmed,
                CommentDate = x.CreationDate.ToFarsi(),
                IsCanceled = x.IsCanceled,
                Message = x.Message,
                ProductName = x.Product.Name
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
