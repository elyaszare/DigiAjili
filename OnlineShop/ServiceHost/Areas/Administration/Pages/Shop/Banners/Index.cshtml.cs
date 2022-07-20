using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Banner;

namespace ServiceHost.Areas.Administration.Pages.Shop.Banners
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public List<BannerViewModel> Banners;

        private readonly IBannerApplication _bannerApplication;

        public IndexModel(IBannerApplication slideApplication)
        {
            _bannerApplication = slideApplication;
        }

        public void OnGet()
        {
            Banners = _bannerApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateBanner();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateBanner command)
        {
            var result = _bannerApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _bannerApplication.GetDetails(id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditBanner command)
        {
            var result = _bannerApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _bannerApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _bannerApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
