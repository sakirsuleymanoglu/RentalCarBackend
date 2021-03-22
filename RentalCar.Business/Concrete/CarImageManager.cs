using RentalCar.Business.Abstract;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(Car car, string imagePath)
        {
            var result = BusinessRules.Run(CheckImageCountForCar(car.Id));

            if (result != null)
            {
                return new ErrorResult();
            }

            _carImageDal.Add(new CarImage
            {
                CarId = car.Id,
                ImagePath = imagePath,
                Date = DateTime.Now
            });

            return new SuccessResult();
        }

        public IResult CheckImageCountForCar(int carId)
        {
            var result = _carImageDal.GetAll(cImage => cImage.CarId == carId);

            if (result.Count > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
