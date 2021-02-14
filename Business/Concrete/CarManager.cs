using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        public IResult Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public IResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
