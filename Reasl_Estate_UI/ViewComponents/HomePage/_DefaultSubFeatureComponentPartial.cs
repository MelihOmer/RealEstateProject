﻿using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
