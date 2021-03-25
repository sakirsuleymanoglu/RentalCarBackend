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

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByModelYear(string modelYear)
        {
            var result = _carDal.GetAll(c => c.ModelYear == modelYear);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetAllByModel(string model)
        {
            var result = _carDal.GetAll(c => c.Model == model);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }

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
                return new ErrorResult();
            }

            _carDal.Delete(car);

            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckExistOfCar(car.Id));

            if (result != null)
            {
                return new ErrorResult();
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

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(result);
            }

            return new SuccessDataResult<List<CarDetailsDto>>(result);
        }
    }
}
