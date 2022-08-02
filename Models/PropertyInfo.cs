
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Events;

namespace PropertyInspection_WebApp.Models
{
    public class PropertyInfo
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("PropertyAddress")]
        public string PropertyAddress { get; set; }

        [BsonElement("ClientFName")]
        public string ClientFName { get; set; }

        [BsonElement("ClientLName")]
        public string ClientLName { get; set; }

        [BsonElement("InspectionType")]
        public string InspectionType { get; set; }

        [BsonElement("InspectionDateTime")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime InspectionDateTime { get; set; }

        [BsonElement("WhenAdded")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime WhenAdded { get; set; }

        [BsonElement("AddedBy")]
        public string AddedBy { get; set; }
    }
}

