using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PropertyInspection_WebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Inspection()
        {
            return View();
        }
    }
}

