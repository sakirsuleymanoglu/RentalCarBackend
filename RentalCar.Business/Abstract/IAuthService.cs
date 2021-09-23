using RentalCar.Core.Entities.Concrete;
using RentalCar.Core.Utilities.Results;
using RentalCar.Core.Utilities.Security.Jwt;
using RentalCar.Entities.DTOs;

namespace RentalCar.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
