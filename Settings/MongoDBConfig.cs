using System;
namespace PropertyInspection_WebApp.Settings
{
    public class MongoDBConfig
    {
        public string Name { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string ConnectionString => $"mongodb+srv://system:WCTPEMeCebceg466@piwebappcluster.i6ipfdi.mongodb.net/?retryWrites=true&w=majority";
    }
}

