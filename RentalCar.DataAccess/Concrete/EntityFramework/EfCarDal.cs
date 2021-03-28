using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.DataAccess.EntityFramework;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailsDto> GetAllDetailsByBrandId(int brandId)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where b.Id == brandId
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Images = null,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
        }

        public CarDetailsDto GetDetailsByCarId(int carId)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == carId
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Images = null,
                                 DailyPrice = c.DailyPrice
                             };

                return result.SingleOrDefault();
            }
        }

        public List<CarDetailsDto> GetAllDetailsByColorId(int colorId)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where co.Id == colorId             
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Images = null,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetAllDetailsOfCars()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Images = null,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
