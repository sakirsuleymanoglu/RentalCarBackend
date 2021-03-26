using RentalCar.Business.Abstract;
using RentalCar.Core.Business;
using RentalCar.Core.Entities.Concrete;
using RentalCar.Core.Utilities.Results;
using RentalCar.Core.Utilities.Security.Hashing;
using RentalCar.Core.Utilities.Security.Jwt;
using RentalCar.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var result = _userService.GetClaims(user);

            if (!result.Success)
            {
                return new ErrorDataResult<AccessToken>();
            }

            var userClaims = result.Data;

            var accessToken = _tokenHelper.CreateToken(user, userClaims);

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByEMail(userForLoginDto.Email).Data;

            if (user == null)
            {
                return new ErrorDataResult<User>();
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>();
            }

            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;

            var result = BusinessRules.Run(CheckIfUserAlreadyExists(userForRegisterDto.Email));

            if (result != null)
            {
                return new ErrorDataResult<User>();
            }

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user);
        }

        public IResult CheckIfUserAlreadyExists(string email)
        {
            var result = _userService.GetByEMail(email);

            if (!result.Success)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
