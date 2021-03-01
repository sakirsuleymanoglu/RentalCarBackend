using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetAllByCar(int carId);
        IDataResult<List<Rental>> GetAllByCustomer(int customerId);
        IDataResult<Rental> Get(int id);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
