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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetRentals()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return Problem(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetRentalById(int id)
        {
            var result = _rentalService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return Problem(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.Update(rental);
            return Ok(result);
        }
    }
}
