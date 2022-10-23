using System;
namespace PropertyInspection_WebApp.Settings
{
    public class MongoDBConfig
    {
        /// <summary>
        /// This cs file works as a .config file.
        /// All DB names and tables are declared and accessed by other classes by using Dependency Injection.
        /// This class can be injected into the calling class's constructor.
        /// </summary>
        public string Name { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string ConnectionString => $"mongodb+srv://system:WCTPEMeCebceg466@piwebappcluster.i6ipfdi.mongodb.net/?retryWrites=true&w=majority";

        //DATABASES
        public string IdentityDatabaseName = "Identity"; //System DB - Do not alter.
        public string PropertyDatabaseName = "PropertyDB";

        //TABLES
        public string PropertyInfoTableName = "t_PropertyInfo";
        public string PropertyImagesTableName = "t_PropertyImages";
    }
}

