using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Utilities.Uploads
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
