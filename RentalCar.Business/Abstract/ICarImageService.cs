using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using System.Collections.Generic;

namespace RentalCar.Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(int carId, string imagePath);
        IResult Delete(int carId, int imagePathId);
        IResult Update(int carId, int imagePathId, string newImagePath);
        IDataResult<List<CarImage>> GetAllImagesByCarId(int carId);
        IDataResult<CarImage> GetImageByCarId(int carId, int imagePathId);
    }
}
