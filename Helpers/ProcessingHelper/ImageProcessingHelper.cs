using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using PropertyInspection_WebApp.Models;


namespace PropertyInspection_WebApp.Helpers.ProcessingHelper
{
    public static class ImageProcessingHelper
    {
        /// <summary>
        /// Accepts a IFormFile and converts it to byte array and then encodes it to base64 string.
        /// </summary>
        /// <param name="rawImage"></param>
        /// <returns>byte[]</returns>
        public static byte[] ProcessImageForDBInsert(IFormFile rawImage)
        {
            if (rawImage.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    rawImage.CopyTo(ms);
                    var processedImageInBytes = ms.ToArray();
                    return processedImageInBytes;
                }
            }
            return null;
        }

    }


}

