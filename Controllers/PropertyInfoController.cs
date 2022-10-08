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
            try
            {
                propertyInfo.InspectionType = Convert.ToString(TempData["pk_inspectionType"]);

                var result = _propertyInfoRepo.Save(propertyInfo);

                TempData["pk_property_address"] = propertyInfo.PropertyAddress;
                TempData["pk_property_ClientName"] = propertyInfo.ClientFName + ' ' + propertyInfo.ClientLName;
                TempData["pk_property_inspectionType"] = propertyInfo.InspectionType;

                if (result = TransactionResultHelper.True)
                    ViewBag.Message = "Property Information added successfully";
                else
                    ViewBag.Message = "Property Information was not saved successfully";

                ModelState.Clear();

                WaitForViewBagReloadHelper.ExecuteWait();

                return View("~/Views/ModularForms/ModularLandingPage.cshtml");
            }
            catch (Exception)
            {
                return View("~/Views/ExceptionHandling/redirectToErrorPage.cshtml");
            }
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
