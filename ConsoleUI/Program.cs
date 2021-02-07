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

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            foreach (var car in result)
            {
                Console.WriteLine("Brand Name : " + car.BrandName + " " + "Color : " + car.ColorName + " " + "Daily Price : " + car.DailyPrice);
            }
        }
    }
}
