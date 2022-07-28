using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Debugger.Contracts;
using PropertyInspection_WebApp.Models;

namespace PropertyInspection_WebApp.IRepository
{
    public interface IPropertyInfoRepository
    {
        PropertyInfo Save(PropertyInfo propertyinfo);
        PropertyInfo Get(string PropertyId);
        List<PropertyInfo> Gets();
        string Delete(string PropertyId);
    }
}

