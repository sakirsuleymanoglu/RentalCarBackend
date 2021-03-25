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
        private ICarService _carService;
        private ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

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

            return NotFound(result);
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
            string path = GetPath();

            string imagePath = FileHelper.CreateFile(path, formFile);

            var result = _carImageService.Add(carId, imagePath);

            if (result.Success)
            {
                return Ok(result);
            }

            FileHelper.DeleteFile(imagePath);

            return BadRequest(result);
        }

        [HttpPut("updateimage")]
        public IActionResult UpdateImage(IFormFile formFile, int carId, int imagePathId)
        {
            string path = GetPath();

            string imagePath = FileHelper.CreateFile(path, formFile);

            var result = _carImageService.Update(carId, imagePathId, imagePath);

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
            string path = GetPath();

            string defaultImagePath = path + FileHelper.GetDefaultImagePath(path, "jpg");

            var result = _carImageService.GetAllByCarId(carId, new List<CarImage>
            {
                new CarImage { ImagePath = defaultImagePath }
            });

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [NonAction]
        public string GetPath()
        {
            return _webHostEnvironment.WebRootPath + "\\uploads\\";
        }
    }
}
