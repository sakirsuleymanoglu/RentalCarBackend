using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(result, Messages.ErrorListCars);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.SuccessListCars);
        }

        public IDataResult<Car> Get(int id)
        {
            var result = _carDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Car>(result, Messages.ErrorGetCarById);
            }
            return new SuccessDataResult<Car>(result, Messages.SuccessGetCarById);
        }

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
