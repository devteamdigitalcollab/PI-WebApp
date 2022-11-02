using System;
using System.Reflection.Metadata;

namespace PropertyInspection_WebApp.Settings
{
    public class PIConfigurations
    {
        /// <summary>
        /// This cs file works as a .config file.
        /// All DB names and tables are declared and accessed by other classes by using Dependency Injection.
        /// This class can be injected into the calling class's constructor.
        /// </summary>
        public string NAME { get; init; }
        public string USERNAME { get; init; }
        public string PASSWORD { get; init; }
        public string CONNECTIONSTRING => $"mongodb+srv://{USERNAME}:{PASSWORD}@piwebappcluster.dprjgsi.mongodb.net/?retryWrites=true&w=majority";

        //DATABASES
        public string IDENTITYDATABASENAME = "Identity"; //System DB - Do not alter.
        public string PROPERTYDATABASENAME = "PROPERTY_DB";
        public string BUILDING_ELEMENTS_DATABASENAME = "BUILDING_ELEMENTS_DB";

        //TABLES
        public string PROPERTYINFOTABLE = "c_property_info";
        public string FOUNDATIONTABLE = "c_foundation";


        //GRIDFS BUCKETNAMES
        public string PROPERTYINFOBUCKETNAME = "GFS_property_info_images";
        public string FOUNDATIONBUCKETNAME = "GFS_foundation_images";

        //GRIDFS GENERIC CHUNCKSIZE = 1MB
        public int CHUNCKSIZE = 1048576;
    }
}

