using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RentalCar.Core.Utilities.File
{
    public static class FileHelper
    {
        public static string CreateFile(string path, IFormFile formFile)
        {
            string imagePath = null;

            try
            {
                if (formFile.Length > 0)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    imagePath = path + Guid.NewGuid() + formFile.FileName;

                    using (FileStream fileStream = System.IO.File.Create(imagePath))
                    {
                        formFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                return imagePath;
            }
            catch (Exception)
            {
                return "Resim yüklerken bir hata oluştu";
            }
        }

        public static void DeleteFile(string imagePath)
        {
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        public static string GetDefaultImagePath(string path)
        {
            return path + "default.jpg";
        }
    }
}
