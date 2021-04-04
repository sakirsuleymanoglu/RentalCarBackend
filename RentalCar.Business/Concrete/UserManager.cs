using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Core.Entities.Concrete;
using RentalCar.Business.Utilities.Constants;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Security.Hashing;
using RentalCar.Entities.DTOs;

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

            return new SuccessResult(Messages.UserInsertionSuccess);
        }

        public IResult CheckIfIsAdmin(int userId)
        {
            var result = BusinessRules.Run(CheckIfExistsUser(userId));

            if (result != null)
            {
                return result;
            }

            var claims = _userDal.GetClaims(userId);

            var claim = claims.SingleOrDefault(c => c.Name == "admin");

            if (claim == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            var result = BusinessRules.Run(CheckIfExistsUser(user.Id));

            if (result != null)
            {
                return result;
            }

            _userDal.Delete(user);

            return new SuccessResult(Messages.UserDeletedSuccess);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();

            return new SuccessDataResult<List<User>>(result, Messages.UsersListed);
        }

        public IDataResult<User> GetByEMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);

            if (result != null)
            {
                return new SuccessDataResult<User>(result, Messages.ThereIsAEmail);
            }

            return new ErrorDataResult<User>(Messages.EmailNotFound);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            return new SuccessDataResult<User>(result, Messages.ThereIsAUser);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user.Id);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<OperationClaim>>(result, Messages.UserClaimsListed);
            }

            return new ErrorDataResult<List<OperationClaim>>(Messages.UserClaimsNotFound);
        }

        public IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId)
        {
            var result = BusinessRules.Run(CheckIfExistsUser(userId));

            if (result != null)
            {
                return new ErrorDataResult<List<OperationClaim>>(result.Message);
            }

            var claims = _userDal.GetClaims(userId);

            return new SuccessDataResult<List<OperationClaim>>(claims);
        }

        public IResult Update(UserForRegisterDto userForRegisterDto, int userId)
        {
            var userAlreadyExistsCheck = BusinessRules.Run(CheckIfUserAlreadyExists(userForRegisterDto.Email));

            if (userAlreadyExistsCheck != null)
            {
                return new ErrorDataResult<User>(userAlreadyExistsCheck.Message);
            }

            byte[] passwordHash, passwordSalt;

            var result = BusinessRules.Run(CheckIfExistsUser(userId));

            if (result != null)
            {
                return result;
            }

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = _userDal.Get(u => u.Id == userId);

            user.Email = userForRegisterDto.Email;
            user.FirstName = userForRegisterDto.FirstName;
            user.LastName = userForRegisterDto.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = true;

            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdatedSuccess);
        }

        public IResult CheckIfUserAlreadyExists(string email)
        {
            var result = _userDal.Get(u=>u.Email == email);

            if (result != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }


        private IResult CheckIfExistsUser(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);

            if (result == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            return new SuccessResult();
        }
    }
}
