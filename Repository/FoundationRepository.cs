using MongoDB.Bson;
using MongoDB.Driver;
using PropertyInspection_WebApp.Helpers.ProcessingHelper;
using PropertyInspection_WebApp.Helpers.TrasnactionHelper;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Models.PrePurchaseModels.BuildingElementsModels;
using PropertyInspection_WebApp.Settings;
using System;
using System.Collections.Generic;

namespace PropertyInspection_WebApp.Repository
{
    public class FoundationRepository : IFoundationRepository
    {
        #region Private Members

        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<FoundationModel> _foundationTable = null;

        #endregion Private Members

        //DBConfig Injected
        public FoundationRepository(PIConfigurations pIConfigurations)
        {
            _mongoClient = new MongoClient(pIConfigurations.CONNECTIONSTRING);
            _mongoDatabase = _mongoClient.GetDatabase(pIConfigurations.BUILDING_ELEMENTS_DATABASENAME);
            _foundationTable = _mongoDatabase.GetCollection<FoundationModel>(pIConfigurations.FOUNDATIONTABLE);
        }

        public byte[] RawImageAPL_file { get; private set; }
        public byte[] RawImageAPS_file { get; private set; }
        public byte[] RawImageDBR_file { get; private set; }
        public byte[] RawImageDR_file { get; private set; }
        public byte[] RawImageECS_file { get; private set; }
        public byte[] RawImageECT_file { get; private set; }
        public byte[] RawImageFL_file { get; private set; }
        public byte[] RawImageFT_file { get; private set; }
        public byte[] RawImageFW_file { get; private set; }
        public byte[] RawImageGC_file { get; private set; }
        public byte[] RawImageGCLR_file { get; private set; }
        public byte[] RawImageGVB_file { get; private set; }
        public byte[] RawImageIC_file { get; private set; }
        public byte[] RawImageIP_file { get; private set; }
        public byte[] RawImageIT_file { get; private set; }
        public byte[] RawImageITH_file { get; private set; }
        public byte[] RawImageNR_file { get; private set; }
        public byte[] RawImageOSA_file { get; private set; }
        public byte[] RawImagePS_file { get; private set; }
        public byte[] RawImagePT_file { get; private set; }
        public byte[] RawImagePTBC_file { get; private set; }
        public byte[] RawImageTFB_file { get; private set; }
        public byte[] RawImageVL_file { get; private set; }

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
        public FoundationModel Get(string FoundationId)
        {
            try
            {
                return _foundationTable.Find(x => x.FoundationId == FoundationId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        /// <summary>
        /// Checks if the foundation for the associated property is added to the DB
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns>boolean</returns>
        /// <exception cref="GetException"></exception>
        public bool GetFoundationByPropertyId(string PropertyId)
        {
            try
            {
                var DbCheck = _foundationTable.Find(x => x.PropertyId == PropertyId).FirstOrDefault();
                if (DbCheck != null)
                {
                    return TransactionResultHelper.True;
                }
                else
                {
                    return TransactionResultHelper.False;
                }
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

                //Uses Image processing helpers to prepare image for DB insert
                //Inserts Image to GridFS DB
                if (foundationModel.RawImageAPL != null && !string.IsNullOrEmpty(foundationModel.RawImageAPL.Name))
                {
                    RawImageAPL_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageAPL);
                    foundationModel.APLGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageAPL.FileName, RawImageAPL_file);
                }
                if (foundationModel.RawImageAPS != null && !string.IsNullOrEmpty(foundationModel.RawImageAPS.Name))
                {
                    RawImageAPS_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageAPS);
                    foundationModel.APSGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageAPS.FileName, RawImageAPS_file);
                }
                if (foundationModel.RawImageDBR != null && !string.IsNullOrEmpty(foundationModel.RawImageDBR.Name))
                {
                    RawImageDBR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageDBR);
                    foundationModel.DBRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageDBR.FileName, RawImageDBR_file);
                }
                if (foundationModel.RawImageDR != null && !string.IsNullOrEmpty(foundationModel.RawImageDR.Name))
                {
                    RawImageDR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageDR);
                    foundationModel.DRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageDR.FileName, RawImageDR_file);
                }
                if (foundationModel.RawImageECS != null && !string.IsNullOrEmpty(foundationModel.RawImageECS.Name))
                {
                    RawImageECS_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageECS);
                    foundationModel.ECSGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageECS.FileName, RawImageECS_file);
                }
                if (foundationModel.RawImageECT != null && !string.IsNullOrEmpty(foundationModel.RawImageECT.Name))
                {
                    RawImageECT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageECT);
                    foundationModel.ECTGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageECT.FileName, RawImageECT_file);
                }
                if (foundationModel.RawImageFL != null && !string.IsNullOrEmpty(foundationModel.RawImageFL.Name))
                {
                    RawImageFL_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageFL);
                    foundationModel.FLGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageFL.FileName, RawImageFL_file);
                }
                if (foundationModel.RawImageFT != null && !string.IsNullOrEmpty(foundationModel.RawImageFT.Name))
                {
                    RawImageFT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageFT);
                    foundationModel.FTGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageFT.FileName, RawImageFT_file);
                }
                if (foundationModel.RawImageFW != null && !string.IsNullOrEmpty(foundationModel.RawImageFW.Name))
                {
                    RawImageFW_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageFW);
                    foundationModel.FWGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageFW.FileName, RawImageFW_file);
                }
                if (foundationModel.RawImageGC != null && !string.IsNullOrEmpty(foundationModel.RawImageGC.Name))
                {
                    RawImageGC_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageGC);
                    foundationModel.GCGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageGC.FileName, RawImageGC_file);
                }
                if (foundationModel.RawImageGCLR != null && !string.IsNullOrEmpty(foundationModel.RawImageGCLR.Name))
                {
                    RawImageGCLR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageGCLR);
                    foundationModel.GCLRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageGCLR.FileName, RawImageGCLR_file);
                }
                if (foundationModel.RawImageGVB != null && !string.IsNullOrEmpty(foundationModel.RawImageGVB.Name))
                {
                    RawImageGVB_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageGVB);
                    foundationModel.GVBGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageGVB.FileName, RawImageGVB_file);
                }
                if (foundationModel.RawImageIC != null && !string.IsNullOrEmpty(foundationModel.RawImageIC.Name))
                {
                    RawImageIC_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageIC);
                    foundationModel.ICGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageIC.FileName, RawImageIC_file);
                }
                if (foundationModel.RawImageIP != null && !string.IsNullOrEmpty(foundationModel.RawImageIP.Name))
                {
                    RawImageIP_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageIP);
                    foundationModel.IPGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageIP.FileName, RawImageIP_file);
                }
                if (foundationModel.RawImageIT != null && !string.IsNullOrEmpty(foundationModel.RawImageIT.Name))
                {
                    RawImageIT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageIT);
                    foundationModel.ITGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageIT.FileName, RawImageIT_file);
                }
                if (foundationModel.RawImageITH != null && !string.IsNullOrEmpty(foundationModel.RawImageITH.Name))
                {
                    RawImageITH_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageITH);
                    foundationModel.ITHGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageITH.FileName, RawImageITH_file);
                }
                if (foundationModel.RawImageNR != null && !string.IsNullOrEmpty(foundationModel.RawImageNR.Name))
                {
                    RawImageNR_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageNR);
                    foundationModel.NRGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageNR.FileName, RawImageNR_file);
                }
                if (foundationModel.RawImageOSA != null && !string.IsNullOrEmpty(foundationModel.RawImageOSA.Name))
                {
                    RawImageOSA_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageOSA);
                    foundationModel.OSAGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageOSA.FileName, RawImageOSA_file);
                }
                if (foundationModel.RawImagePS != null && !string.IsNullOrEmpty(foundationModel.RawImagePS.Name))
                {
                    RawImagePS_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImagePS);
                    foundationModel.PSGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImagePS.FileName, RawImagePS_file);
                }
                if (foundationModel.RawImagePT != null && !string.IsNullOrEmpty(foundationModel.RawImagePT.Name))
                {
                    RawImagePT_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImagePT);
                    foundationModel.PTGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImagePT.FileName, RawImagePT_file);
                }
                if (foundationModel.RawImagePTBC != null && !string.IsNullOrEmpty(foundationModel.RawImagePTBC.Name))
                {
                    RawImagePTBC_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImagePTBC);
                    foundationModel.PTBCGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImagePTBC.FileName, RawImagePTBC_file);
                }
                if (foundationModel.RawImageTFB != null && !string.IsNullOrEmpty(foundationModel.RawImageTFB.Name))
                {
                    RawImageTFB_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageTFB);
                    foundationModel.TFBGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageTFB.FileName, RawImageTFB_file);
                }
                if (foundationModel.RawImageVL != null && !string.IsNullOrEmpty(foundationModel.RawImageVL.Name))
                {
                    RawImageVL_file = ImageProcessingHelper.ProcessImageForDBInsert(foundationModel.RawImageVL);
                    foundationModel.VLGridFSID = ImageGridFSHelper.InsertImageToGridFS(_mongoDatabase, foundationModel.RawImageVL.FileName, RawImageVL_file);
                }

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