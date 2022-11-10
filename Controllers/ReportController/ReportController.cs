using Microsoft.AspNetCore.Mvc;
using PropertyInspection_WebApp.IRepository;
using System;

namespace PropertyInspection_WebApp.Controllers.ReportController
{
    [Route("Report/{id}")]
    public class ReportController : Controller
    {
        public IPropertyInfoRepository PropertyInfoRepository { get; set; }

        public ReportController(IPropertyInfoRepository propertyInfoRepository)
        {
            PropertyInfoRepository = propertyInfoRepository;
        }


        public IActionResult PrePurchaseReport(string id)
        {
            var propertyInfo = PropertyInfoRepository.Get(id);
            TempData["pk_property_id"] = propertyInfo.PropertyId;
            return View("~/Views/Reports/Pre-PurchaseReport/PrePurchaseMainReportView.cshtml", propertyInfo);
        }

    }
}
