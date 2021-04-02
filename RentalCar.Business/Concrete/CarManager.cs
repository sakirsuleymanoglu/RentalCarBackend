using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;
using RentalCar.Business.Abstract;
using RentalCar.Business.Utilities.Constants;
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
        private readonly IBrandService _brandService;
        private readonly IColorService _colorService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();

            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result = BusinessRules.Run(CheckIfExistsBrand(brandId));

            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }

            var cars = _carDal.GetAll(c => c.BrandId == brandId);

            return new SuccessDataResult<List<Car>>(cars, Messages.CarsListed);
        }

        private IResult CheckIfExistsBrand(int brandId)
        {
            var result = _brandService.GetById(brandId);

            if (result == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }

            return new SuccessResult(Messages.ThereIsABrand);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            var result = BusinessRules.Run(CheckIfExistsColor(colorId));

            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }

            var cars = _carDal.GetAll(c => c.ColorId == colorId);

            return new SuccessDataResult<List<Car>>(cars, Messages.CarsListed);
        }

        private IResult CheckIfExistsColor(int colorId)
        {
            var result = _colorService.GetById(colorId);

            if (result == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }

            return new SuccessResult(Messages.ThereIsAColor);
        }

        public IDataResult<List<Car>> GetAllByModelYear(string modelYear)
        {
            var result = _carDal.GetAll(c => c.ModelYear == modelYear);

            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByModel(string model)
        {
            var result = _carDal.GetAll(c => c.Model == model);

            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.Id == id);

            return new SuccessDataResult<Car>(result, Messages.ThereIsACar);
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarInsertionSuccess);
        }

        public IResult Delete(Car car)
        {
            var result = BusinessRules.Run(CheckExistOfCar(car.Id));

            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeletedSuccess);
        }

        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckExistOfCar(car.Id));

            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdatedSuccess);
        }

        private IResult CheckExistOfCar(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);

            if (result == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            return new SuccessResult(Messages.ThereIsACar);
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetails()
        {
            var result = _carDal.GetAllDetailsOfCars();

            return new SuccessDataResult<List<CarDetailsDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetAllDetailsByBrandId(brandId);

            return new SuccessDataResult<List<CarDetailsDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetailsByColorId(int colorId)
        {
            var result = _carDal.GetAllDetailsByColorId(colorId);

            return new SuccessDataResult<List<CarDetailsDto>>(result, Messages.CarsListed);
        }

        public IDataResult<CarDetailsDto> GetDetailsByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckExistOfCar(carId));

            if (result != null)
            {
                return new ErrorDataResult<CarDetailsDto>(result.Message);
            }

            return new SuccessDataResult<CarDetailsDto>(_carDal.GetDetailsByCarId(carId), Messages.CarsListed);
        }
    }
}
