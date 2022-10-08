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
        public string CONNECTIONSTRING => $"mongodb+srv://system:WCTPEMeCebceg466@piwebappcluster.i6ipfdi.mongodb.net/?retryWrites=true&w=majority";

        //DATABASES
        public string IDENTITYDATABASENAME = "Identity"; //System DB - Do not alter.
        public string PROPERTYDATABASENAME = "PropertyDB";

        //TABLES
        public string PROPERTYINFOTABLE = "PropertyInfo";

        //GRIDFS BUCKETNAMES
        public string PROPERTYINFOBUCKETNAME = "PropertyInfo_Images";

        //GRIDFS GENERIC CHUNCKSIZE = 1MB
        public int CHUNCKSIZE = 1048576;
    }
}

