using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductPictureSearchModel SearchModel;
        public List<SlideViewModel> Slides;

        private readonly ISlideApplication SlideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            SlideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = SlideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = SlideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = SlideApplication.GetDetails(id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = SlideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = SlideApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = SlideApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
