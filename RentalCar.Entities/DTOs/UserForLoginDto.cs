using RentalCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
