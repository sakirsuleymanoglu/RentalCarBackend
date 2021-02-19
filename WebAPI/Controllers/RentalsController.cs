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

            return BadRequest(result.Message);
        }

        [HttpGet("getallbycarid/{carid}")]
        public IActionResult GetRentalsByCarId(int carId)
        {
            var result = _rentalService.GetAllByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallbycustomerid/{customerid}")]
        public IActionResult GetRentalsByCustomerId(int customerId)
        {
            var result = _rentalService.GetAllByCarId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetRentalById(int id)
        {
            var result = _rentalService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (result.Success)
            {
                return Created("", result);
            }

            return Problem(result.Message);
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
