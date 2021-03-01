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
            var result = _carService.GetAllByBrand(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{colorId}")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetAllByColor(colorId);

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
    }
}
