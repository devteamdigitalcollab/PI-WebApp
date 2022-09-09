using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Debugger.Contracts;
using PropertyInspection_WebApp.Models;

namespace PropertyInspection_WebApp.IRepository
{
    public interface IPropertyInfoRepository
    {
        bool Save(PropertyInfo propertyinfo);
        PropertyInfo Get(string PropertyId);
        List<PropertyInfo> Gets();
        string Delete(string PropertyId);
    }
}

