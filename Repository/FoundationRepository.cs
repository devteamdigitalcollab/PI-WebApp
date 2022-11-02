using System;
using MongoDB.Bson;
using MongoDB.Driver;
using PropertyInspection_WebApp.Helpers.ProcessingHelper;
using PropertyInspection_WebApp.Helpers.TrasnactionHelper;
using PropertyInspection_WebApp.Settings;
using System.Collections.Generic;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels;
using MongoDB.Bson.Serialization.IdGenerators;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PropertyInspection_WebApp.Repository
{
    public class FoundationRepository : IFoundationRepository
    {
        #region Private Members
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<FoundationModel> _foundationTable = null;
        #endregion  Private Members

        //DBConfig Injected
        public FoundationRepository(PIConfigurations pIConfigurations)
        {
            _mongoClient = new MongoClient(pIConfigurations.CONNECTIONSTRING);
            _mongoDatabase = _mongoClient.GetDatabase(pIConfigurations.BUILDING_ELEMENTS_DATABASENAME);
            _foundationTable = _mongoDatabase.GetCollection<FoundationModel>(pIConfigurations.FOUNDATIONTABLE);

        }

        /// <summary>
        /// Deletes a single foudation using the PropertyId
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        /// <exception cref="DeleteException"></exception>
        public string Delete(string PropertyId)
        {
            try
            {
                _foundationTable.DeleteOne(x => x.PropertyId == PropertyId);
                return "Deleted";
            }
            catch (Exception ex)
            {
                throw new DeleteException(ex.Message);
            }
        }

        /// <summary>
        /// Gets the foudation information for a single property using the PropertyId
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        /// <exception cref="GetsException"></exception>
        public FoundationModel Get(string PropertyId)
        {
            try
            {
                return _foundationTable.Find(x => x.PropertyId == PropertyId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        /// <summary>
        /// Gets all the foudations listed in the databse
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GetsException"></exception>
        public List<FoundationModel> Gets()
        {
            try
            {
                return _foundationTable.Find(FilterDefinition<FoundationModel>.Empty).ToList();
            }
            catch (Exception ex)
            {
                throw new GetsException(ex.Message);
            }
        }

        /// <summary>
        /// Saves a single foudation to the databse using the foundationModel object
        /// </summary>
        /// <param name="foundationModel"></param>
        /// <returns></returns>
        /// <exception cref="SaveException"></exception>
        public bool Save(FoundationModel foundationModel)
        {
            try
            {
                foundationModel.FoundationId = ObjectId.GenerateNewId().ToString();

                var RawImageAPL_filename = foundationModel.RawImageAPL.FileName;
                var RawImageAPS_filename = foundationModel.RawImageAPS.FileName;
                var RawImageDBR_filename = foundationModel.RawImageDBR.FileName;
                var RawImageDR_filename = foundationModel.RawImageDR.FileName;
                var RawImageECS_filename = foundationModel.RawImageECS.FileName;
                var RawImageECT_filename = foundationModel.RawImageECT.FileName;
                var RawImageFL_filename = foundationModel.RawImageFL.FileName;
                var RawImageFT_filename = foundationModel.RawImageFT.FileName;
                var RawImageFW_filename = foundationModel.RawImageFW.FileName;
                var RawImageGC_filename = foundationModel.RawImageGC.FileName;
                var RawImageGCLR_filename = foundationModel.RawImageGCLR.FileName;
                var RawImageGVB_filename = foundationModel.RawImageGVB.FileName;
                var RawImageIC_filename = foundationModel.RawImageIC.FileName;
                var RawImageIP_filename = foundationModel.RawImageIP.FileName;
                var RawImageIT_filename = foundationModel.RawImageIT.FileName;
                var RawImageITH_filename = foundationModel.RawImageITH.FileName;
                var RawImageNR_filename = foundationModel.RawImageNR.FileName;
                var RawImageOSA_filename = foundationModel.RawImagePLT.FileName;
                var RawImagePS_filename = foundationModel.RawImagePS.FileName;
                var RawImagePT_filename = foundationModel.RawImagePT.FileName;
                var RawImagePTBC_filename = foundationModel.RawImagePTBC.FileName;
                var RawImageTFB_filename = foundationModel.RawImageTFB.FileName;
                var RawImageVL_filename = foundationModel.RawImageVL.FileName;


                //Uses Image processing helpers to prepare image for DB insert
                var RawImageAPL_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageAPL);
                var RawImageAPS_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageAPS);
                var RawImageDBR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageDBR);
                var RawImageDR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageDR);
                var RawImageECS_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageECS);
                var RawImageECT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageECT);
                var RawImageFL_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageFL);
                var RawImageFT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageFT);
                var RawImageFW_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageFW);
                var RawImageGC_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageGC);
                var RawImageGCLR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageGCLR);
                var RawImageGVB_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageGVB);
                var RawImageIC_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageIC);
                var RawImageIP_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageIP);
                var RawImageIT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageIT);
                var RawImageITH_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageITH);
                var RawImageNR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageNR);
                var RawImageOSA_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageOSA);
                var RawImagePS_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImagePS);
                var RawImagePT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImagePT);
                var RawImagePTBC_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImagePTBC);
                var RawImageTFB_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageTFB);
                var RawImageVL_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageVL);




                //Inserts Image to GridFS DB
                foundationModel.APLGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageAPL_filename, RawImageAPL_file);
                foundationModel.APSGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageAPS_filename, RawImageAPS_file);
                foundationModel.DBRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageDBR_filename, RawImageDBR_file);
                foundationModel.DRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageDR_filename, RawImageDR_file);
                foundationModel.ECSGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageECS_filename, RawImageECS_file);
                foundationModel.ECTGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageECT_filename, RawImageECT_file);
                foundationModel.FLGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageFL_filename, RawImageFL_file);
                foundationModel.FTGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageFT_filename, RawImageFT_file);
                foundationModel.FWGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageFW_filename, RawImageFW_file);
                foundationModel.GCGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageGC_filename, RawImageGC_file);
                foundationModel.GCLRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageGCLR_filename, RawImageGCLR_file);
                foundationModel.GVBGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageGVB_filename, RawImageGVB_file);
                foundationModel.ICGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageIC_filename, RawImageIC_file);
                foundationModel.IPGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageIP_filename, RawImageIP_file);
                foundationModel.ITGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageIT_filename, RawImageIT_file);
                foundationModel.ITHGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageITH_filename, RawImageITH_file);
                foundationModel.NRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageNR_filename, RawImageNR_file);
                foundationModel.OSAGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageOSA_filename, RawImageOSA_file);
                foundationModel.PSGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImagePS_filename, RawImageIP_file);
                foundationModel.PTGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImagePT_filename, RawImagePT_file);
                foundationModel.PTBCGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImagePTBC_filename, RawImagePTBC_file);
                foundationModel.TFBGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageTFB_filename, RawImageTFB_file);
                foundationModel.VLGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, RawImageVL_filename, RawImageVL_file);

                // Check if value already exists in DB, IF not create new ELSE relpace existing
                var result = _foundationTable.Find(x => x.PropertyId == foundationModel.PropertyId).FirstOrDefault();
                if (result == null)
                {
                    _foundationTable.InsertOne(foundationModel);
                }
                else
                {
                    _foundationTable.ReplaceOne(x => x.PropertyId == foundationModel.PropertyId, foundationModel);
                }
                return TransactionResultHelper.True;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex.Message);
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
}

