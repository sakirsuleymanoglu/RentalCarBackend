using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using RentalCar.Business.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Core.Utilities.Results;
using RentalCar.Core.Utilities.File;

namespace RentalCar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICarImageService _carImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarsController(ICarService carService, ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carService = carService;
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetails")]
        public IActionResult GetAllDetails()
        {
            var result = _carService.GetAllDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetailsbybrandid")]
        public IActionResult GetAllDetailsByBrand(int brandId)
        {
            var result = _carService.GetAllDetailsByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetailsbycolorid")]
        public IActionResult GetAllDetailsByColor(int colorId)
        {
            var result = _carService.GetAllDetailsByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getwithdetailsbycarid")]
        public IActionResult GetDetails(int carId)
        {
            var result = _carService.GetDetailsByCarId(carId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            result.Data.Images = _carImageService.GetAllImagesByCarId(carId).Data;

            if (result.Data.Images.Count == 0)
            {
                result.Data.Images = new List<CarImage>{
                    new CarImage
                    {
                        CarId = carId,
                        ImagePath = FileHelper.GetDefaultImagePath("jpg")
                    }
                };
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbybrandid")]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbycolorid")]
        public IActionResult GetAllByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbymodelyear")]
        public IActionResult GetAllByModelYear(string modelYear)
        {
            var result = _carService.GetAllByModelYear(modelYear);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbymodel")]
        public IActionResult GetAllByModel(string model)
        {
            var result = _carService.GetAllByModel(model);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addimage")]
        public IActionResult AddImage(IFormFile formFile, int carId)
        {
            string image = FileHelper.CreateFile(GetStaticUploadPath(), formFile);

            var result = _carImageService.Add(carId, image);

            if (result.Success)
            {
                return Ok(result);
            }

            FileHelper.DeleteFile(GetStaticUploadPath() + image);

            return BadRequest(result);
        }

        [HttpPut("updateimage")]
        public IActionResult UpdateImage(IFormFile formFile, int carId, int imagePathId)
        {
            string image = FileHelper.CreateFile(GetStaticUploadPath(), formFile);

            var result = _carImageService.Update(carId, imagePathId, image);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleteimage")]
        public IActionResult DeleteImage(int carId, int imagePathId)
        {
            var result = _carImageService.Delete(carId, imagePathId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallimages")]
        public IActionResult GetAllImages(int carId)
        {
            var result = _carImageService.GetAllImagesByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [NonAction]
        public string GetStaticUploadPath()
        {
            return _webHostEnvironment.WebRootPath + "\\uploads\\";
        }
    }
}
