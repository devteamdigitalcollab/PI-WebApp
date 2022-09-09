using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyInspection_WebApp.Controllers
{
    public class ModularFormController : Controller
    {
        private readonly IPropertyInfoRepository _propertyInfo;
        public ModularFormController(IPropertyInfoRepository propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public IActionResult BuildingElements()
        {
            return View("~/Views/ModularForms/BuildingElementsSub/Foundation.cshtml");
        }

        public IActionResult InteriorElements()
        {
            return View("~/Views/ModularForms/InteriorElementsSub/InteriorElements.cshtml");
        }

        public IActionResult ExteriorElements()
        {
            return View("~/Views/ModularForms/ExteriorElementsSub/ExteriorElements.cshtml");
        }

        public IActionResult GeneralElements()
        {
            return View("~/Views/ModularForms/GeneralElementsSub/GeneralElements.cshtml");
        }

        public IActionResult ExteriorSiteElements()
        {
            return View("~/Views/ModularForms/ExteriorSiteElementsSub/ExteriorSiteElements.cshtml");
        }

        public IActionResult Index()
        {

            return View("~/Views/ModularForms/ModularLandingPage.cshtml");
        }
    }
}

