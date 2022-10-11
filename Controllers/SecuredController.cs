using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PropertyInspection_WebApp.Controllers
{
    [Authorize(Roles = "SYSTEM, ADMIN, INSPECTOR")]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("SYSTEM") || User.IsInRole("ADMIN"))
            {
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return RedirectToAction("InspectorDashboard");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDeniedIndex()
        {
            return View();
        }


        public IActionResult AdminDashboard()
        {
            return View("~/Views/Dashboard/AdminDashboard.cshtml");
        }

        public IActionResult InspectorDashboard()
        {
            return View("~/Views/Dashboard/InspectorDashboard.cshtml");
        }
    }
}

