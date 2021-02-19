using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetCars()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallbybrandid/{brandid}")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallbycolorid/{colorid}")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallbymodelyear/{modelyear}")]
        public IActionResult GetCarsByModelYear(string modelYear)
        {
            var result = _carService.GetAllByModelYear(modelYear);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Created("", result);
            }

            return Problem(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);

            return Ok(result);
        }

        [HttpDelete("update")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);

            return Ok(result);
        }
    }
}
