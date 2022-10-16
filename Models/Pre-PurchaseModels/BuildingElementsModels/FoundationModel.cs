using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels
{
    public class FoundationModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        /// <summary>
        /// Primary Key 
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; }

        [Required]
        [BsonElement("PropertyAddress")]
        public string PropertyAddress { get; set; }

        [Required]
        [BsonElement("ClientFName")]
        public string ClientFName { get; set; }
    }
}

