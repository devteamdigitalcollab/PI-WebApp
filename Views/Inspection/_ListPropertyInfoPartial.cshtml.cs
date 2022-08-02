using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropertyInspection_WebApp.Models;
using PropertyInspection_WebApp.Repository;

namespace PropertyInspection_WebApp.Views
{
    public class _ListPropertyInfoPartialModel : PageModel
    {
        private readonly PropertyInfoRepository _propertyInfoRepository;
        public _ListPropertyInfoPartialModel(PropertyInfoRepository PropInfoRepo)
        {
            _propertyInfoRepository = PropInfoRepo;
        }
        public List<PropertyInfo> PropertyInfoList { get; set; }

        public void OnGet()
        {
            PropertyInfoList = _propertyInfoRepository.Gets();
        }
    }
}
