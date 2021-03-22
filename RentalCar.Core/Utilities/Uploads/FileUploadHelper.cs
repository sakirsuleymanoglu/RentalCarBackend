using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RentalCar.Core.Utilities.Uploads
{
    public static class FileUploadHelper
    {
        public static string Upload(FileUpload upload, IHostEnvironment hostEnvironment)
        {
            string imagePath = null;

            try
            {
                if (upload.files.Length > 0)
                {
                    string path = hostEnvironment.ContentRootPath + "\\uploads\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    imagePath = path + new Guid() + upload.files.FileName;

                    using (FileStream fileStream = System.IO.File.Create(imagePath))
                    {
                        upload.files.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }

                return imagePath;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }
    }
}
