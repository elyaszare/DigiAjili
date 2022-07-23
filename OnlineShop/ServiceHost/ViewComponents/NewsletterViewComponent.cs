using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class NewsletterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
