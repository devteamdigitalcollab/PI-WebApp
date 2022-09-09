using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace PropertyInspection_WebApp.Models
{
    public class InspectionModel
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; }

        [Required]
        [BsonElement("InspectionType")]
        public string InspectionType { get; set; }

        [Required]
        [BsonElement("InspectionDateTime")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyyTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime InspectionDateTime { get; set; }

        [BsonElement("WhenAdded")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyyTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime WhenAdded { get; set; } = DateTime.Now;

        [Required]
        [BsonElement("AddedBy")]
        public string AddedBy { get; set; }


    }
}

