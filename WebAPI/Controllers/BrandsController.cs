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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetBrands()
        {
            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            var result = _brandService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Add(brand);

            if (result.Success)
            {
                return Created("", brand);
            }

            return Problem(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.Delete(brand);

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.Update(brand);

            return Ok(result);
        }
    }
}