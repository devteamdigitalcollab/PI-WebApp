using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PropertyInspection_WebApp.Controllers
{
    [Authorize(Roles = "Admin, Inspector")]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminDashboard");
            }
            else
                return RedirectToAction("InspectorDashboard");
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

