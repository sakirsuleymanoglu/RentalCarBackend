using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(int carId, string imagePath);
        IResult Delete(int carId, string imagePath);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> GetByCarIdAndImagePath(int carId, string imagePath);
    }
}
