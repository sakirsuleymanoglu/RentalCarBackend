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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            var result = _userService.Add(user);

            if (result.Success)
            {
                return Created("", result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.Delete(user);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var result = _userService.Update(user);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
