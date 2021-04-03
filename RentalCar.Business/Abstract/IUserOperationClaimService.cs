using RentalCar.Core.Entities.Concrete;
using RentalCar.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult AddDefaultClaim(int userId);
    }
}
