using System;
using System.Collections.Generic;
using PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels;

namespace PropertyInspection_WebApp.IRepository
{
    public interface IFoundationRepository
    {
        bool Save(FoundationModel foundation);
        FoundationModel Get(string PropertyId);
        List<FoundationModel> Gets();
        string Delete(string PropertyId);
    }
}

