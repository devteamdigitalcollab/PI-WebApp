using System;
using System.Collections.Generic;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using MongoDB.Driver;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models;
using PropertyInspection_WebApp.Settings;

namespace PropertyInspection_WebApp.Repository
{
    public class PropertyInfoRepository : IPropertyInfoRepository
    {
        // Private Members
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<PropertyInfo> _propertyInfoTable = null;

        //DBConfig Injected
        public PropertyInfoRepository(MongoDBConfig mongoDBConfig)
        {
            _mongoClient = new MongoClient(mongoDBConfig.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(mongoDBConfig.PropertyDatabaseName);
            _propertyInfoTable = _mongoDatabase.GetCollection<PropertyInfo>(mongoDBConfig.PropertyInfoTableName);

        }

        public string Delete(string PropertyId)
        {
            _propertyInfoTable.DeleteOne(x => x.PropertyId == PropertyId);
            return "Deleted";
        }

        public PropertyInfo Get(string PropertyId)
        {
            return _propertyInfoTable.Find(x => x.PropertyId == PropertyId).FirstOrDefault();
        }

        public List<PropertyInfo> Gets()
        {
            return _propertyInfoTable.Find(FilterDefinition<PropertyInfo>.Empty).ToList();
        }

        public PropertyInfo Save(PropertyInfo propertyinfo)
        {
            var propertyInfoObj = _propertyInfoTable.Find(x => x.PropertyId == propertyinfo.PropertyId).FirstOrDefault();
            if (propertyInfoObj == null)
                _propertyInfoTable.InsertOne(propertyinfo);
            else
                _propertyInfoTable.ReplaceOne(x => x.PropertyId == propertyinfo.PropertyId, propertyinfo);
            return propertyinfo;
        }
    }
}

