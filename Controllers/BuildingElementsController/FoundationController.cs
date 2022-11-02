using System;
using Microsoft.AspNetCore.Mvc;
using PropertyInspection_WebApp.Helpers.WaitHelper;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels;

namespace PropertyInspection_WebApp.Controllers.BuildingElementsController
{
    [Route("BuildingElements/Foundation")]
    public class FoundationController : Controller
    {
        private IFoundationRepository _foundationRepository;

        public FoundationController(IFoundationRepository foundationRepository)
        {
            _foundationRepository = foundationRepository;
        }

        public JsonResult GetFoundations()
        {
            var foudations = _foundationRepository.Gets();
            return Json(foudations);
        }

        [HttpPost]
        public IActionResult SaveFoundation(FoundationModel foundationModel)
        {
            try
            {
                //Insert Property in DB
                var result = _foundationRepository.Save(foundationModel);

                ModelState.Clear();

                WaitForViewBagReloadHelper.ExecuteWait();

                return RedirectToAction("FoundationIndex", "ModularForm", new { fId = foundationModel.FoundationId, pId = foundationModel.PropertyId });

            }
            catch (Exception)
            {
                return View("~/Views/ExceptionHandling/redirectToErrorPage.cshtml");
            }
        }

        public JsonResult DeleteFoundation(string propertyId)
        {
            var message = _foundationRepository.Delete(propertyId);
            return Json(message);
        }
    }
}


