using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RentalCar.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car
                {
                    Id=1,
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 150,
                    ModelYear = "2014",
                    Description = "Araba 1"
                },
                new Car
                {
                    Id=2,
                    BrandId = 3,
                    ColorId = 5,
                    DailyPrice = 200,
                    ModelYear = "2010",
                    Description = "Araba 2"
                },
                new Car
                {
                    Id=3,
                    BrandId = 2,
                    ColorId = 3,
                    DailyPrice = 125,
                    ModelYear = "2007",
                    Description = "Araba 3"
                }
            };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            var deletedEntity = _cars.SingleOrDefault(c=>c.Id == entity.Id);
            _cars.Remove(deletedEntity);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return null;
        }

        public void Update(Car entity)
        {
            var updatedEntity = _cars.SingleOrDefault(c => c.Id == entity.Id);
            updatedEntity.BrandId = 10;
            updatedEntity.ColorId = 5;
            updatedEntity.DailyPrice = 500;
            updatedEntity.ModelYear = "2020";
        }
    }
}
