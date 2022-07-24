using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PropertyInspection_WebApp.Controllers
{
    [Authorize(Roles = "Admin, System")]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminDashboard");
            }

            return RedirectToAction("AccessDeniedIndex");
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

