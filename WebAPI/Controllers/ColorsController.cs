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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetColors()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return Problem(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetColorById(int id)
        {
            var result = _colorService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return Problem(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.Delete(color);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);
            return Ok(result);
        }
    }
}
