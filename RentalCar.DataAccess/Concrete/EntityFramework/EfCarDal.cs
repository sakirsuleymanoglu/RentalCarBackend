using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.DataAccess.EntityFramework;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailsDto> GetAllDetailsOfCars()
        {
            var result = 
        }
    }
}
