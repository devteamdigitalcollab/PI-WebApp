using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
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
        public string FoundationId { get; set; }

        /// <summary>
        /// Foreign Key 
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; }

        [Required]
        [BsonElement("AddedBy")]
        public string AddedBy { get; set; }

        [Required]
        [BsonElement("FoundationNote")]
        public string FoundationNote { get; set; }



        [Required]
        [BsonElement("AccessPointLocation")]
        public string AccessPointLocation { get; set; }

        [BsonIgnore]
        public IFormFile RawImageAPL { get; set; }

        [BsonElement("APLGridFSID")]
        public string APLGridFSID { get; set; }



        [Required]
        [BsonElement("AccessPointSize")]
        public string AccessPointSize { get; set; }

        [BsonIgnore]
        public IFormFile RawImageAPS { get; set; }

        [BsonElement("APSGridFSID")]
        public string APSGridFSID { get; set; }



        [Required]
        [BsonElement("FoundationWall")]
        public string FoundationWall { get; set; }

        [BsonIgnore]
        public IFormFile RawImageFW { get; set; }

        [BsonElement("FWGridFSID")]
        public string FWGridFSID { get; set; }




        [Required]
        [BsonElement("GroundCondition")]
        public string GroundCondition { get; set; }

        [BsonIgnore]
        public IFormFile RawImageGC { get; set; }

        [BsonElement("GCGridFSID")]
        public string GCGridFSID { get; set; }




        [Required]
        [BsonElement("GroundVapourBarrier")]
        public string GroundVapourBarrier { get; set; }

        [BsonIgnore]
        public IFormFile RawImageGVB { get; set; }

        [BsonElement("GVBGridFSID")]
        public string GVBGridFSID { get; set; }



        [Required]
        [BsonElement("Drainage")]
        public string Drainage { get; set; }

        [BsonIgnore]
        public IFormFile RawImageDR { get; set; }

        [BsonElement("DRGridFSID")]
        public string DRGridFSID { get; set; }


        [Required]
        [BsonElement("Ventilation")]
        public string Ventilation { get; set; }

        [BsonIgnore]
        public IFormFile RawImageVL { get; set; }

        [BsonElement("VLGridFSID")]
        public string VLGridFSID { get; set; }




        [Required]
        [BsonElement("PileType")]
        public string PileType { get; set; }

        [BsonIgnore]
        public IFormFile RawImagePT { get; set; }

        [BsonElement("PTGridFSID")]
        public string PTGridFSID { get; set; }




        [Required]
        [BsonElement("PileToBearerConnections")]
        public string PileToBearerConnections { get; set; }

        [BsonIgnore]
        public IFormFile RawImagePTBC { get; set; }

        [BsonElement("PTBCGridFSID")]
        public string PTBCGridFSID { get; set; }



        [Required]
        [BsonElement("ObviousStructuralAlteration")]
        public string ObviousStructuralAlteration { get; set; }

        [BsonIgnore]
        public IFormFile RawImageOSA { get; set; }

        [BsonElement("OSAGridFSID")]
        public string OSAGridFSID { get; set; }



        [Required]
        [BsonElement("GroundClearance")]
        public string GroundClearance { get; set; }

        [BsonIgnore]
        public IFormFile RawImageGCLR { get; set; }

        [BsonElement("GCLRGridFSID")]
        public string GCLRGridFSID { get; set; }



        [Required]
        [BsonElement("FloorType")]
        public string FloorType { get; set; }

        [BsonIgnore]
        public IFormFile RawImageFT { get; set; }

        [BsonElement("FTGridFSID")]
        public string FTGridFSID { get; set; }




        [Required]
        [BsonElement("TimberFramingBracing")]
        public string TimberFramingBracing { get; set; }

        [BsonIgnore]
        public IFormFile RawImageTFB { get; set; }

        [BsonElement("TFBGridFSID")]
        public string TFBGridFSID { get; set; }




        [Required]
        [BsonElement("InsulationType")]
        public string InsulationType { get; set; }

        [BsonIgnore]
        public IFormFile RawImageIT { get; set; }

        [BsonElement("ITGridFSID")]
        public string ITGridFSID { get; set; }



        [Required]
        [BsonElement("InsulationThickness")]
        public string InsulationThickness { get; set; }

        [BsonIgnore]
        public IFormFile RawImageITH { get; set; }

        [BsonElement("ITHGridFSID")]
        public string ITHGridFSID { get; set; }



        [Required]
        [BsonElement("InsulationCoverage")]
        public string InsulationCoverage { get; set; }

        [BsonIgnore]
        public IFormFile RawImageIC { get; set; }

        [BsonElement("ICGridFSID")]
        public string ICGridFSID { get; set; }




        [Required]
        [BsonElement("ElectricalCableType")]
        public string ElectricalCableType { get; set; }

        [BsonIgnore]
        public IFormFile RawImageECT { get; set; }

        [BsonElement("ECTGridFSID")]
        public string ECTGridFSID { get; set; }




        [Required]
        [BsonElement("ElectricalCableSupport")]
        public string ElectricalCableSupport { get; set; }

        [BsonIgnore]
        public IFormFile RawImageECS { get; set; }

        [BsonElement("ECSGridFSID")]
        public string ECSGridFSID { get; set; }




        [Required]
        [BsonElement("PlumbingType")]
        public string PlumbingType { get; set; }

        [BsonIgnore]
        public IFormFile RawImagePLT { get; set; }

        [BsonElement("PLTGridFSID")]
        public string PLTGridFSID { get; set; }



        [Required]
        [BsonElement("PlumbingSupport")]
        public string PlumbingSupport { get; set; }

        [BsonIgnore]
        public IFormFile RawImagePS { get; set; }

        [BsonElement("PSGridFSID")]
        public string PSGridFSID { get; set; }



        [Required]
        [BsonElement("InsectsPests")]
        public string InsectsPests { get; set; }

        [BsonIgnore]
        public IFormFile RawImageIP { get; set; }

        [BsonElement("IPGridFSID")]
        public string IPGridFSID { get; set; }



        [Required]
        [BsonElement("Debris")]
        public string Debris { get; set; }

        [BsonIgnore]
        public IFormFile RawImageDBR { get; set; }

        [BsonElement("DBRGridFSID")]
        public string DBRGridFSID { get; set; }



        [Required]
        [BsonElement("FloorLevels")]
        public string FloorLevels { get; set; }

        [BsonIgnore]
        public IFormFile RawImageFL { get; set; }

        [BsonElement("FLGridFSID")]
        public string FLGridFSID { get; set; }


        [Required]
        [BsonElement("NotesRecommendations")]
        public string NotesRecommendations { get; set; }

        [BsonIgnore]
        public IFormFile RawImageNR { get; set; }

        [BsonElement("NRGridFSID")]
        public string NRGridFSID { get; set; }

    }
}

