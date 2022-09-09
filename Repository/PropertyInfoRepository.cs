using System;
using System.Collections.Generic;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models;
using PropertyInspection_WebApp.Settings;
using PropertyInspection_WebApp.Helpers.TrasnactionHelper;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

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

        public bool Save(PropertyInfo propertyinfo)
        {
            try
            {
                propertyinfo.PropertyId = ObjectId.GenerateNewId().ToString();

                // Check if value already exists in DB, IF not create new ELSE relpace existing
                var result = _propertyInfoTable.Find(x => x.PropertyId == propertyinfo.PropertyId).FirstOrDefault();
                if (result == null)
                {
                    _propertyInfoTable.InsertOne(propertyinfo);
                }
                else
                {
                    _propertyInfoTable.ReplaceOne(x => x.PropertyId == propertyinfo.PropertyId, propertyinfo);
                }
                return TransactionResultHelper.True;
            }
            catch (Exception ex)
            {
                throw new BsonException(Convert.ToString(ex));
            }
        }
    }
}

