using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class EstateAgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
