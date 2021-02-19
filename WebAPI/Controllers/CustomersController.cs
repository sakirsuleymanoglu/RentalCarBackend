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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetCustomers()
        {
            var result = _customerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.Add(customer);

            if (result.Success)
            {
                return Created("", result);
            }

            return Problem(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var result = _customerService.Delete(customer);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.Update(customer);

            return Ok(result);
        }
    }
}
