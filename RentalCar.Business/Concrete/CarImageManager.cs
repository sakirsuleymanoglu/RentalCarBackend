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

        public IResult Delete(int carId, int imagePath)
        {
            var result = BusinessRules.Run(CheckIfExistCar(carId),
                CheckIfExistImageForCar(carId, imagePath));

            if (result != null)
            {
                return new ErrorResult();
            }

            var carImage = GetImageByCarId(carId, imagePath).Data;

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

        private IResult CheckIfExistCar(int carId)
        {
            var result = _carService.GetById(carId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistImageForCar(int carId, int imagePathId)
        {
            var result = _carImageDal.Get(c => c.CarId == carId && c.Id == imagePathId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IDataResult<CarImage> GetImageByCarId(int carId, int imagePath)
        {
           var result =  BusinessRules.Run(CheckIfExistCar(carId), CheckIfExistImageForCar(carId, imagePath));

            if (result!=null)
            {
                return new ErrorDataResult<CarImage>();
            }

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId && c.Id == imagePath));
        }

        public IResult Update(int carId, int imagePathId, string newImagePath)
        {
            return null;
        }

       
    }
}
