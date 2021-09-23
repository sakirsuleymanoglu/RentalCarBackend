using RentalCar.Core.Entities.Concrete;
using System.Collections.Generic;

namespace RentalCar.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
