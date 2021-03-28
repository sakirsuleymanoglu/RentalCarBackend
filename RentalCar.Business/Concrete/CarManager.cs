using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;
using RentalCar.Business.Abstract;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByModelYear(string modelYear)
        {
            var result = _carDal.GetAll(c => c.ModelYear == modelYear);

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByModel(string model)
        {
            var result = _carDal.GetAll(c => c.Model == model);

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Car>();
            }

            return new SuccessDataResult<Car>(result);
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            var result = BusinessRules.Run(CheckExistOfCar(car.Id));

            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);

            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckExistOfCar(car.Id));

            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);

            return new SuccessResult();
        }

        private IResult CheckExistOfCar(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetails()
        {
            var result = _carDal.GetAllDetailsOfCars();

            return new SuccessDataResult<List<CarDetailsDto>>(result);
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetAllDetailsByBrandId(brandId);

            return new SuccessDataResult<List<CarDetailsDto>>(result);
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetailsByColorId(int colorId)
        {
            var result = _carDal.GetAllDetailsByColorId(colorId);

            return new SuccessDataResult<List<CarDetailsDto>>(result);
        }

        public IDataResult<CarDetailsDto> GetDetailsByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckExistOfCar(carId));

            if (result!=null)
            {
                return new ErrorDataResult<CarDetailsDto>();
            }

            return new SuccessDataResult<CarDetailsDto>(_carDal.GetDetailsByCarId(carId));
        }
    }
}
