using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Add(int carId, string path)
        {
            _carImageDal.Add(new CarImage
            {
                CarId = carId,
                ImagePath = path,
                Date = DateTime.Now
            });

            return new SuccessResult();
        }
    }
}
