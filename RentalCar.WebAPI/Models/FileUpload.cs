using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RentalCar.WebAPI.Models
{
    public class FileUpload
    {
        public IFormFile FormFile { get; set; }
    }
}
