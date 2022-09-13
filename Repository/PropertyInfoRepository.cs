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
using PropertyInspection_WebApp.Helpers.ProcessingHelper;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.GridFS;
using System.Net.Sockets;
using Microsoft.Build.Framework;

namespace PropertyInspection_WebApp.Repository
{
    public class PropertyInfoRepository : IPropertyInfoRepository
    {
        // Private Members
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<PropertyInfo> _propertyInfoTable = null;
        private GridFSBucket _gridFSBucket;
        private PropertyInfo _propertyInfo;
        private string _bucketName = null;
        private int _chunckSize = 0;



        //DBConfig Injected
        public PropertyInfoRepository(PIConfigurations pIConfigurations)
        {
            _mongoClient = new MongoClient(pIConfigurations.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(pIConfigurations.PropertyDatabaseName);
            _propertyInfoTable = _mongoDatabase.GetCollection<PropertyInfo>(pIConfigurations.PropertyInfoTableName);
            _bucketName = pIConfigurations.PROPERTYINFOBUCKETNAME;
            _chunckSize = pIConfigurations.CHUNCKSIZE;
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
                var filetToUpload = ImageProcessingHelper.ProcessImageForDBInsert(propertyinfo.RawImageFile);
                //Instansiates GridFSBucket
                var filename = propertyinfo.RawImageFile.FileName;

                _gridFSBucket = new GridFSBucket(_mongoDatabase, new GridFSBucketOptions
                {
                    BucketName = _bucketName,
                    ChunkSizeBytes = _chunckSize,
                    WriteConcern = WriteConcern.WMajority,
                    ReadPreference = ReadPreference.Secondary
                });
                var options = new GridFSUploadOptions
                {
                    ChunkSizeBytes = 64512, // 63KB
                    Metadata = new BsonDocument
                    {
                        { "resolution", "1080P" },
                        { "copyrighted", true }
                    }
                };
                //Uploads to DB using GridFS and return string ID
                var id = _gridFSBucket.UploadFromBytes(filename, filetToUpload, options);

                //Sets ID to proprerty model
                propertyinfo.ImageGridFSID = Convert.ToString(id);

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
                throw new BsonException("Error:", ex);
            }
        }


    }
}

