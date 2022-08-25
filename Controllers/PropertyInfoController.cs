using System.Threading;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models;
using PropertyInspection_WebApp.Repository;

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

        public IActionResult SavePropertyInfo(PropertyInfo propertyInfo)
        {
            var p = _propertyInfoRepo.Save(propertyInfo);

            if (p != null)
                ViewBag.Message = "Property Information added Successfully";
            return View("~/Views/ModularForms/ModularLandingPage.cshtml");

        }

        public JsonResult DeletePropertyInfo(string propertyId)
        {
            var message = _propertyInfoRepo.Delete(propertyId);
            return Json(message);
        }


        public IActionResult Index()
        {

            return View("~/Views/ModularForms/ModularLandingPage.cshtml");
            //return View("~/Views/Inspection/PropertyInfo.cshtml");
        }
    }
}
