
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver.Core.Events;
using MongoDB.Libmongocrypt;

namespace PropertyInspection_WebApp.Models
{
    public class PropertyInfo
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

        [Required]
        [BsonElement("ClientLName")]
        public string ClientLName { get; set; }

        [Required]
        [BsonElement("PeoplePresent")]
        public int PeoplePresent { get; set; }

        [Required]
        [BsonElement("HouseOccupied")]
        public string HouseOccupied { get; set; }

        [Required]
        [BsonElement("LegalDescription")]
        public string LegalDescription { get; set; }

        [Required]
        [BsonElement("CertOfTitle")]
        public string CertOfTitle { get; set; }

        [BsonIgnore]
        public IFormFile RawImageFile { get; set; }

        [Required]
        [BsonElement("InspectionType")]
        public string InspectionType { get; set; }

        [Required]
        [BsonElement("PropertyImage")]
        public string PropertyImage { get; set; }


        [BsonElement("ImageGridFSID")]
        public string ImageGridFSID { get; set; }

        [BsonElement("WhenAdded")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyyTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime WhenAdded { get; set; } = DateTime.Now;

        [Required]
        [BsonElement("AddedBy")]
        public string AddedBy { get; set; }

    }
}
