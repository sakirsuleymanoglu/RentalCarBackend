using System.Collections.Generic;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<Car>> GetAllByModel(string model);
        IDataResult<List<Car>> GetAllByModelYear(string modelYear);
        IDataResult<List<CarDetailsDto>> GetAllDetails();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailsDto>> GetAllDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetAllDetailsByColorId(int colorId);
        IDataResult<CarDetailsDto> GetDetailsByCarId(int carId);
    }
}
