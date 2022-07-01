using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        OperationResult AddComment(AddComment command);
        OperationResult Confirm(long id);
        OperationResult Cancel(long id);
        List<CommentViewModel> Get();
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
