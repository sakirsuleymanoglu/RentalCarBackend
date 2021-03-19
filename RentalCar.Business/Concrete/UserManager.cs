using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<User>>();
            }

            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<User>();
            }

            return new SuccessDataResult<User>(result);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _userDal.Delete(user);

            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _userDal.Update(user);

            return new SuccessResult();
        }
    }
}
