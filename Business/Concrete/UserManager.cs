using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.SuccessAddUser);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult(Messages.SuccessDeleteUser);
        }

        public IDataResult<User> Get(int id)
        {
            var result = _userDal.Get(u => u.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.ErrorGetUserById);
            }

            return new SuccessDataResult<User>(result, Messages.SuccessGetUserById);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.ErrorListUsers);
            }

            return new SuccessDataResult<List<User>>(result, Messages.SuccessListUsers);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult(Messages.SuccessUpdateUser);
        }
    }
}
