using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PropertyInspection_WebApp.Helpers.ProcessingHelper;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models;
using PropertyInfo = PropertyInspection_WebApp.Models.PropertyInfo;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyInspection_WebApp.Controllers
{
    public class ModularFormController : Controller
    {
        private readonly IPropertyInfoRepository _propertyInfoRepo;

        public ModularFormController(IPropertyInfoRepository propertyInfoRepo)
        {
            _propertyInfoRepo = propertyInfoRepo;

        }


        #region LandingPage Views
        public IActionResult Index(string id)
        {
            LoadPropertyInfoForSideBar(id);
            CheckDbForInsert(id);

            return View("~/Views/ModularForms/ModularLandingPage.cshtml");
        }

        public IActionResult RedirectedIndexCall(string id)
        {
            LoadPropertyInfoForSideBar(id);
            return View("~/Views/ModularForms/ModularLandingPage.cshtml");
        }
        #endregion LandingPage Views


        #region BuildingElements Sub Views

        public IActionResult Foundation(string id)
        {
            LoadPropertyInfoForSideBar(id);
            return View("~/Views/ModularForms/BuildingElementsSub/Foundation.cshtml");
        }

        public IActionResult WallFraming(string id)
        {
            LoadPropertyInfoForSideBar(id);
            return View("~/Views/ModularForms/BuildingElementsSub/WallFraming.cshtml");
        }

        public IActionResult RoofSpace(string id)
        {
            LoadPropertyInfoForSideBar(id);
            return View("~/Views/ModularForms/BuildingElementsSub/RoofSpace.cshtml");
        }

        #endregion BuildingElements Sub Views




        #region InteriorElements Sub Views

        public IActionResult InteriorElements()
        {

            return View("~/Views/ModularForms/InteriorElementsSub/InteriorElements.cshtml");
        }

        #endregion InteriorElements Sub Views

        #region ExteriorElements Sub Views
        public IActionResult ExteriorElements()
        {

            return View("~/Views/ModularForms/ExteriorElementsSub/ExteriorElements.cshtml");
        }
        #endregion ExteriorElements Sub Views

        #region GeneralElements Sub Views
        public IActionResult GeneralElements()
        {

            return View("~/Views/ModularForms/GeneralElementsSub/GeneralElements.cshtml");
        }
        #endregion GeneralElements Sub View

        #region ExteriorSiteElements Sub Views
        public IActionResult ExteriorSiteElements()
        {
            return View("~/Views/ModularForms/ExteriorSiteElementsSub/ExteriorSiteElements.cshtml");
        }
        #endregion ExteriorSiteElements Sub Views



        #region Helpers

        /// <summary>
        /// Fetches the property info for the id that has been passed
        /// and updated the view TempData for the calling view
        /// </summary>
        /// <param name="id"></param>
        public void LoadPropertyInfoForSideBar(string id)
        {

            //Retrieve the propertyDetails using the Property Id
            var propertyDetails = _propertyInfoRepo.Get(id);

            //Set the temp UI variable for property for next view
            TempData["pk_property_id"] = propertyDetails.PropertyId;
            TempData["pk_property_address"] = propertyDetails.PropertyAddress;
            TempData["pk_property_ClientName"] = propertyDetails.ClientFName + ' ' + propertyDetails.ClientLName;
            TempData["pk_property_inspectionType"] = propertyDetails.InspectionType;

        }

        /// <summary>
        /// Check if the passed property has been added to the DB and updates the viewbag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string CheckDbForInsert(string id)
        {
            var propertyDetails = _propertyInfoRepo.Get(id);

            if (propertyDetails.PropertyId == id)
            {
                return ViewBag.Message = "Property Information added successfully";
            }
            else
            {
                return ViewBag.Message = "Property Information was not saved successfully";
            }
        }

        #endregion Helpers

    }

}

