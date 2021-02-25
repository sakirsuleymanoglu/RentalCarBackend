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
using RentalCar.WebAPI.Models;

namespace RentalCar.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        private IWebHostEnvironment _webHostEnvironment;

        public CarsController(ICarService carService, IWebHostEnvironment webHostEnvironment)
        {
            _carService = carService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{brandId}")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetAllByBranId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{colorId}")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("modelYear")]
        public IActionResult GetCarsByModelYear(string modelYear)
        {
            var result = _carService.GetAllByModelYear(modelYear);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{model}")]
        public IActionResult GetCarsByModel(string model)
        {
            var result = _carService.GetAllByModel(model);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Created("", result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost("{carId}")]
        public IActionResult AddImage(int carId, [FromForm] FileUpload objectFile)
        {

            try
            {
                if (objectFile.FormFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + $"\\images\\" + Guid.NewGuid().ToString();
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var file = objectFile.FormFile;

                    var busOfFile = path + file.FileName;

                    using (FileStream fileStream = System.IO.File.Create(busOfFile))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        var result = _carService.AddImage(carId, busOfFile);

                        return Ok();

                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
