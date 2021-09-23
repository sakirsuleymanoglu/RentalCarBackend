﻿using RentalCar.Business.Abstract;
using RentalCar.Business.Utilities.Constants;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.File;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace RentalCar.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(int carId, string imagePath)
        {
            var result = BusinessRules.Run(CheckIfImageCountForCarThanFive(carId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(new CarImage
            {
                CarId = carId,
                ImagePath = imagePath,
                Date = DateTime.Now
            });

            return new SuccessResult(Messages.ImageInsertionSuccess);
        }

        private IResult CheckIfImageCountForCarThanFive(int carId)
        {
            var result = _carImageDal.GetAll(cImage => cImage.CarId == carId);

            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.NumberOfPicturesError);
            }
            return new SuccessResult();
        }

        public IResult Delete(int carId, int imagePathId)
        {
            var result = BusinessRules.Run(CheckIfExistsCar(carId),
                CheckIfExistsImageForCar(carId, imagePathId));

            if (result != null)
            {
                return result;
            }

            var carImage = GetImageByCarId(carId, imagePathId).Data;

            _carImageDal.Delete(carImage);

            FileHelper.DeleteFile(carImage.ImagePath);

            return new SuccessResult(Messages.ImageDeletedSuccess);
        }

        private IResult CheckIfExistsCar(int carId)
        {
            var result = _carService.GetById(carId);

            if (result == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsImageForCar(int carId, int imagePathId)
        {
            var result = BusinessRules.Run(CheckIfExistsCar(carId));

            if (result != null)
            {
                return result;
            }

            var image = _carImageDal.Get(cImage => cImage.CarId == carId && cImage.Id == imagePathId);

            if (image == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }

            return new SuccessResult();
        }

        public IDataResult<CarImage> GetImageByCarId(int carId, int imagePath)
        {
            var result = BusinessRules.Run(CheckIfExistsImageForCar(carId, imagePath));

            if (result != null)
            {
                return new ErrorDataResult<CarImage>(result.Message);
            }

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId && c.Id == imagePath), Messages.ThereIsAImage);
        }

        public IResult Update(int carId, int imagePathId, string newImagePath)
        {
            var result = BusinessRules.Run(CheckIfExistsCar(carId),
               CheckIfExistsImageForCar(carId, imagePathId));

            if (result != null)
            {
                return result;
            }

            var carImage = GetImageByCarId(carId, imagePathId).Data;

            string oldCarImagePath = carImage.ImagePath;

            carImage.ImagePath = newImagePath;

            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);

            FileHelper.DeleteFile(oldCarImagePath);

            return new SuccessResult(Messages.ImageUpdatedSuccess);
        }

        public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfExistsCar(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            var images = _carImageDal.GetAll(c => c.CarId == carId);

            return new SuccessDataResult<List<CarImage>>(images, Messages.PicturesListed);

        }

    }
}
