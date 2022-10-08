using Microsoft.AspNetCore.Mvc;

namespace PropertyInspection_WebApp.Controllers
{
    public class InspectionTypeController : Controller
    {
        public IActionResult PP_Inspection()
        {

            TempData["pk_inspectionType"] = "Pre-Pruchase Inspeciton";
            return RedirectToAction("Index", "PropertyInfo");
        }
    }
}