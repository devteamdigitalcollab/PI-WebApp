using PropertyInspection_WebApp.Models;
using System.Collections.Generic;

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