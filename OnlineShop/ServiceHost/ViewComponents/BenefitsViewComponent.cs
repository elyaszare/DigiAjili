using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class BenefitsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
