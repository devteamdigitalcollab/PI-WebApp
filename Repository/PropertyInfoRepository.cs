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
        #region Private Members
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<PropertyInfo> _propertyInfoTable = null;
        #endregion  Private Members

        //DBConfig Injected
        public PropertyInfoRepository(PIConfigurations pIConfigurations)
        {
            _mongoClient = new MongoClient(pIConfigurations.CONNECTIONSTRING);
            _mongoDatabase = _mongoClient.GetDatabase(pIConfigurations.PROPERTYDATABASENAME);
            _propertyInfoTable = _mongoDatabase.GetCollection<PropertyInfo>(pIConfigurations.PROPERTYINFOTABLE);

        }

        /// <summary>
        /// Deletes a single property using the PropertyId
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        /// <exception cref="DeleteException"></exception>
        public string Delete(string PropertyId)
        {
            try
            {
                _propertyInfoTable.DeleteOne(x => x.PropertyId == PropertyId);
                return "Deleted";
            }
            catch (Exception ex)
            {
                throw new DeleteException(ex.Message);
            }
        }

        /// <summary>
        /// Gets the property information for a single property using the PropertyId
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        /// <exception cref="GetsException"></exception>
        public PropertyInfo Get(string PropertyId)
        {
            try
            {
                return _propertyInfoTable.Find(x => x.PropertyId == PropertyId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetsException(ex.Message);
            }
        }

        /// <summary>
        /// Gets all the properties listed in the databse
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GetsException"></exception>
        public List<PropertyInfo> Gets()
        {
            try
            {
                return _propertyInfoTable.Find(FilterDefinition<PropertyInfo>.Empty).ToList();
            }
            catch (Exception ex)
            {
                throw new GetsException(ex.Message);
            }
        }

        /// <summary>
        /// Saves a single property to the databse using the propertyinfo object
        /// </summary>
        /// <param name="propertyinfo"></param>
        /// <returns></returns>
        /// <exception cref="SaveException"></exception>
        public bool Save(PropertyInfo propertyinfo)
        {
            try
            {
                propertyinfo.PropertyId = ObjectId.GenerateNewId().ToString();
                var filename = propertyinfo.RawImageFile.FileName;

                //Uses Image processing helpers to prepare image for DB insert
                var fileToUpload = ImageProcessingHelper.ProcessImageForDBInsert(propertyinfo.RawImageFile);

                //Inserts Image to GridFS DB
                propertyinfo.ImageGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, filename, fileToUpload); ;

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
                throw new SaveException(ex.Message);
            }
        }


    }

    #region Custom Exceptions

    /// <summary>
    /// An excpetion for Save propety to DB failures
    /// </summary>
    public class SaveException : Exception
    {
        public SaveException(string message)
           : base(message)
        {
        }
    }

    /// <summary>
    /// An excpetion for Get property from DB failures
    /// </summary>
    public class GetException : Exception
    {
        public GetException(string message)
           : base(message)
        {
        }
    }

    /// <summary>
    /// An excpetion for Get all properties from DB failures
    /// </summary>
    public class GetsException : Exception
    {
        public GetsException(string message)
           : base(message)
        {
        }
    }


    /// <summary>
    /// An excpetion for Delete property  failures
    /// </summary>
    public class DeleteException : Exception
    {
        public DeleteException(string message)
           : base(message)
        {
        }
    }
    #endregion Custom Exceptions

}