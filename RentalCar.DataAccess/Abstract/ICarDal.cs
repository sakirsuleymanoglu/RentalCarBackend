using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.DataAccess;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetAllDetailsOfCars();
        List<CarDetailsDto> GetAllDetailsByBrandId(int brandId);
    }
}
