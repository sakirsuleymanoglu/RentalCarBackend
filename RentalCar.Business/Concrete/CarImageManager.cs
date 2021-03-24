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
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(int carId, string imagePath)
        {
            var result = BusinessRules.Run(CheckImageCountForCar(carId));

            if (result != null)
            {
                return new ErrorResult();
            }

            _carImageDal.Add(new CarImage
            {
                CarId = carId,
                ImagePath = imagePath,
                Date = DateTime.Now
            });

            return new SuccessResult();
        }

        public IResult CheckImageCountForCar(int carId)
        {
            var result = _carImageDal.GetAll(cImage => cImage.CarId == carId);

            if (result.Count >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(int carId, string imagePath)
        {
            var result = BusinessRules.Run(CheckIfExistCar(carId),
                CheckIfExistImageForCar(carId, imagePath));

            if (result != null)
            {
                return new ErrorResult();
            }

            var carImage = GetByCarIdAndImagePath(carId, imagePath).Data;

            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(cImage => cImage.CarId == carId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult CheckIfExistCar(int carId)
        {
            var result = _carService.GetById(carId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult CheckIfExistImageForCar(int carId, string imagePath)
        {
            var result = _carImageDal.Get(c => c.CarId == carId && c.ImagePath == imagePath);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IDataResult<CarImage> GetByCarIdAndImagePath(int carId, string imagePath)
        {
           var result =  BusinessRules.Run(CheckIfExistCar(carId), CheckIfExistImageForCar(carId, imagePath));

            if (result!=null)
            {
                return new ErrorDataResult<CarImage>();
            }

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId && c.ImagePath == imagePath));
        }
    }
}
