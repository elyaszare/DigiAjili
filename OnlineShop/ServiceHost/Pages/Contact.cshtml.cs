using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;

        public ContactModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(AddComment command, string articleSlug)
        {
            command.Type = CommentType.Message;
            var result = _commentApplication.AddComment(command);
            return RedirectToPage("/Article", new {Id = articleSlug});
        }
    }
}
