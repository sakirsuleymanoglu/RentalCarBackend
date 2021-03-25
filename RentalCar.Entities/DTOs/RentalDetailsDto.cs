using RentalCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Entities.DTOs
{
    public class RentalDetailsDto : IDto
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
