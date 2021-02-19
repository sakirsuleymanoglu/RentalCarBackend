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
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.Add(user);

            if (result.Success)
            {
                return Created("", result);
            }

            return Problem(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.Delete(user);

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(User user)
        {
            var result = _userService.Update(user);

            return Ok(result);
        }
    }
}
