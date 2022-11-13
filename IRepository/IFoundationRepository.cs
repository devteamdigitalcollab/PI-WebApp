using PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels;
using System.Collections.Generic;

namespace PropertyInspection_WebApp.IRepository
{
    public interface IFoundationRepository 
    {
        bool Save(FoundationModel foundation);

        FoundationModel Get(string FoundationId);

        List<FoundationModel> Gets();

        string Delete(string PropertyId);

        bool isFoundationPresentByPropertyId(string PropertyId);
    }
}