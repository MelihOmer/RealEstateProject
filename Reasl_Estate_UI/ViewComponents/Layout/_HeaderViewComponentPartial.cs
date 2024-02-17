using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.ViewComponents.Layout
{
    public class _HeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
