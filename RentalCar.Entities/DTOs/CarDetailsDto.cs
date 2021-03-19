using RentalCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public string BrandName { get; set; }
        public string CarModel { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
