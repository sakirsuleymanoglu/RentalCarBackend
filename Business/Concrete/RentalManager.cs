using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
