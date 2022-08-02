
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

        [BsonElement("InspectionDate")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime InspectionDate { get; set; }

        [BsonElement("InspectionTime")]
        [BindProperty, DataType(DataType.Time)]
        public DateTime InspectionTime { get; set; }

        [BsonElement("WhenAdded")]
        public DateTime WhenAdded { get; set; }

        [BsonElement("AddedBy")]
        public string AddedBy { get; set; }
    }
}

