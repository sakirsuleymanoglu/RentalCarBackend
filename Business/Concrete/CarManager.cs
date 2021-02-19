using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.ErrorListCars);
            }

            return new SuccessDataResult<List<Car>>(result, Messages.SuccessListCars);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.ErrorListCars);
            }

            return new SuccessDataResult<List<Car>>(result, Messages.SuccessListCars);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.ErrorListCars);
            }

            return new SuccessDataResult<List<Car>>(result, Messages.SuccessListCars);
        }

        public IDataResult<List<Car>> GetAllByModelYear(string modelYear)
        {
            var result = _carDal.GetAll(c => c.ModelYear == modelYear);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.ErrorListCars);
            }

            return new SuccessDataResult<List<Car>>(result, Messages.SuccessListCars);
        }

        public IDataResult<Car> Get(int id)
        {
            var result = _carDal.Get(c => c.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Car>(Messages.ErrorGetCarById);
            }

            return new SuccessDataResult<Car>(result, Messages.SuccessGetCarById);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.SuccessAddCar);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.SuccessDeleteCar);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.SuccessUpdateCar);
        }
    }
}
