using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Entities;

namespace RentalCar.Entities.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
