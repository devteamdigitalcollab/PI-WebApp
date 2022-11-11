using System;
using System.Drawing.Printing;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using PropertyInspection_WebApp.Helpers.TrasnactionHelper;
using PropertyInspection_WebApp.Settings;


namespace PropertyInspection_WebApp.Helpers.ProcessingHelper
{
    public static class ImageGridFSHelper
    {
        /// <summary>
        /// Inserts a file to a GridFS Bucket 
        /// </summary>
        /// <param name="mongoDatabase"></param>
        /// <param name="filename"></param>
        /// <param name="fileToUpload"></param>
        /// <returns>string ObjectId</returns>
        /// <exception cref="NullImageException">Image has not been selected</exception>
        public static string InsertImageToGridFS(IMongoDatabase mongoDatabase, string filename, byte[] fileToUpload)
        {
            var _bucketName = new PIConfigurations().PROPERTYINFOBUCKETNAME;
            var _chunckSize = new PIConfigurations().CHUNCKSIZE;

            if (filename != null && fileToUpload != null)
            {
                var _gridFSBucket = new GridFSBucket(mongoDatabase, new GridFSBucketOptions
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
                var id = _gridFSBucket.UploadFromBytes(filename, fileToUpload, options);
                return Convert.ToString(id);
            }
            else
            {
                throw new NullImageException("Image has not been selected");
            }
        }
        /// <summary>
        /// Returns a byte arrays of the image requested for.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bucketName"></param>
        /// <param name="mongoDatabase"></param>
        /// <returns>byte[]</returns>
        public static byte[] RetrieveImageFromGridFS(string id, string bucketName, IMongoDatabase mongoDatabase)
        {
            var _bucketName = bucketName;
            var _chunckSize = new PIConfigurations().CHUNCKSIZE;
            var objectId = new ObjectId(id);

            if (id != null && bucketName != null)
            {
                var _gridFSBucket = new GridFSBucket(mongoDatabase, new GridFSBucketOptions
                {
                    BucketName = _bucketName,
                    ChunkSizeBytes = _chunckSize,
                    WriteConcern = WriteConcern.WMajority,
                    ReadPreference = ReadPreference.Secondary
                });

                return _gridFSBucket.DownloadAsBytes(objectId);
            }
            return null;
        }
    }

    #region Custom Exceptions
    public class NullImageException : Exception
    {
        public NullImageException(string message)
           : base(message)
        {
        }
    }
    #endregion Custom Exceptions
}

