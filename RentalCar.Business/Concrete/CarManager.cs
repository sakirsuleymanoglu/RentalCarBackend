using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;
using RentalCar.Business.Abstract;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
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

        public IDataResult<List<Car>> GetAllByBranId(int brandId)
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

        public IDataResult<Car> Get(int id)
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
            var result = _carDal.Get(c => c.Id == car.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _carDal.Delete(result);

            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            var result = _carDal.Get(c => c.Id == car.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _carDal.Update(result);

            return new SuccessResult();
        }

        public IResult AddImage(int carId, string path)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carId));

            if (result != null)
            {
                return result;
            }

            _carImageService.Add(carId, path);

            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);

            if (result.Data.Count == 5)
            {
                return new ErrorResult();
            }

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
    }
}
