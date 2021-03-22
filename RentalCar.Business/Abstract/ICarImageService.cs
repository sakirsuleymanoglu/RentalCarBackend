using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(Car car, string imagePath);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
