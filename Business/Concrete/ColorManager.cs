using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public IResult Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public IResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
