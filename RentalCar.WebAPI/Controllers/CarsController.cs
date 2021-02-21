using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalCar.Business.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
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
