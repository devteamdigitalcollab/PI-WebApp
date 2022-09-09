using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropertyInspection_WebApp.Models
{
    public class PropertyImages
    {

        /// <summary>
        /// Foreign Key 
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; }

        [Required]
        [BsonElement("ImageName")]
        public string ImageName { get; set; }

        [Required]
        [BsonElement("Image")]
        public string ImageContent { get; set; }

    }
}

