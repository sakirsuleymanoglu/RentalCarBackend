using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
