using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(int userId);
    }
}
