using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.ViewComponents.HomePage
{
    public class _DefaultDiscountOfDayComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
