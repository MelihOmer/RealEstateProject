using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
