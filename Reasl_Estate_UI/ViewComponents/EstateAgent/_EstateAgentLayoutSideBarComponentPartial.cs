using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLayoutSideBarComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
