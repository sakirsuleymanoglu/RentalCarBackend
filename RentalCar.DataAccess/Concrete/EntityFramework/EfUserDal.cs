using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.DataAccess.EntityFramework;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentalCarContext>, IUserDal
    {
    }
}
