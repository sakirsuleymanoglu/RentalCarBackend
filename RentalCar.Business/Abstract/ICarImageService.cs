using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IResult Add(int carId, string path);
    }
}
