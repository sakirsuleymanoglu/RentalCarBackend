using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color
            {
                Name = "Siyah"
            });

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand
            {
                Name = "BMW"
            });

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 200,
                ModelYear = DateTime.Now,
                Description = "BMW kiralık araba"
            }) ;

        }
    }
}
