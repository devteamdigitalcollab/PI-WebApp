using PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels;
using System.Collections.Generic;

namespace PropertyInspection_WebApp.IRepository
{
    public interface BaseRepository<T> where T : class
    {
        bool Save(T tClass);
        T Get(string tId);
        List<T> Gets();
        string Delete(string tId);
    }
}