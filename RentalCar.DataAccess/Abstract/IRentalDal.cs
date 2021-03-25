using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.DataAccess;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetAllDetailsOfRentals();
    }
}
