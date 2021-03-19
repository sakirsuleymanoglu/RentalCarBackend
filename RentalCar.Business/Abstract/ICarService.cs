using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<Car>> GetAllByModel(string model);
        IDataResult<List<Car>> GetAllByModelYear(string modelYear);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
