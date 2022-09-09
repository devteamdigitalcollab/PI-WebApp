using System.Threading;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models;
using PropertyInspection_WebApp.Repository;
using PropertyInspection_WebApp.Helpers.TrasnactionHelper;
using PropertyInspection_WebApp.Helpers.WaitHelper;
using System;
using Microsoft.AspNetCore.Http;
using MongoDB.Entities;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PropertyInspection_WebApp.Controllers
{
    public class PropertyInfoController : Controller
    {
        private IPropertyInfoRepository _propertyInfoRepo;

        public PropertyInfoController(IPropertyInfoRepository propertyInfoRepo)
        {
            _propertyInfoRepo = propertyInfoRepo;
        }

        public JsonResult GetPropertyInfo()
        {
            var propertyInfos = _propertyInfoRepo.Gets();
            return Json(propertyInfos);
        }

        [HttpPost]
        public IActionResult SavePropertyInfo(PropertyInfo propertyInfo)
        {

            var result = _propertyInfoRepo.Save(propertyInfo);
            TempData["pk_propertyid"] = propertyInfo.PropertyId;

            if (result = TransactionResultHelper.True)
                ViewBag.Message = "Property Information added successfully";
            else
                ViewBag.Message = "Property Information was not saved successfully";

            ModelState.Clear();

            WaitForViewBagReloadHelper.ExecuteWait();

            return View("~/Views/ModularForms/ModularLandingPage.cshtml");
        }

        public JsonResult DeletePropertyInfo(string propertyId)
        {
            var message = _propertyInfoRepo.Delete(propertyId);
            return Json(message);
        }

        public IActionResult Index()
        {

            // return View("~/Views/ModularForms/ModularLandingPage.cshtml");
            return View("~/Views/Inspection/PropertyInfo.cshtml");
        }
    }
}
