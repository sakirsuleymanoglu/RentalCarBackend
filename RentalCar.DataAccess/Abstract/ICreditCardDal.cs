using RentalCar.Core.DataAccess;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.DataAccess.Abstract
{
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
    }
}
