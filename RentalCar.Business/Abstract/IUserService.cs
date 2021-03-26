using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Entities.Concrete;
using RentalCar.Core.Utilities.Results;

namespace RentalCar.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEMail(string email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
