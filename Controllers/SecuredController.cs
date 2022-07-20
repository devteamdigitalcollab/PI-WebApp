using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PropertyInspection_WebApp.Controllers
{
    [Authorize(Roles = "System")]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return RedirectToAction("AccessDeniedIndex");
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDeniedIndex()
        {
            return View();
        }


        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}

