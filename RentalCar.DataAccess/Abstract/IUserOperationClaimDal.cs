using RentalCar.Core.DataAccess;
using RentalCar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
    }
}
