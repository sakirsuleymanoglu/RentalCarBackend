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
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetColors()
        {
            var result = _colorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetColorById(int id)
        {
            var result = _colorService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);

            if (result.Success)
            {
                return Created("", result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.Delete(color);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
