using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Core.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByEMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);

            if (result!=null)
            {
                return new ErrorDataResult<User>();
            }

            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetClaims(int userId)
        {
            var result = _userDal.GetClaims(userId);

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<OperationClaim>>();
            }

            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
