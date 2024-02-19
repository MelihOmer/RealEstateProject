using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
