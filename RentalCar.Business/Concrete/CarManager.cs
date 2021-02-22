using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

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
    }
}
