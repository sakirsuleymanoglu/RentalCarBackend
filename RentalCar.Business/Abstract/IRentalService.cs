using System.Collections.Generic;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailsDto>> GetAllDetails();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<List<Rental>> GetAllByCustomerId(int customerId);
        IDataResult<Rental> GetById(int id);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
