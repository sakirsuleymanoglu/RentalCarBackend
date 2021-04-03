using RentalCar.Core.DataAccess.EntityFramework;
using RentalCar.Core.Entities.Concrete;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaim : EfEntityRepositoryBase<UserOperationClaim, RentalCarContext>, IUserOperationClaimDal
    {
    }
}
