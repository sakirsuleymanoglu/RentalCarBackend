using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Color>>();
            }

            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(c => c.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Color>();
            }

            return new SuccessDataResult<Color>(result);
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            var result = _colorDal.Get(c => c.Id == color.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _colorDal.Delete(color);

            return new SuccessResult();
        }

        public IResult Update(Color color)
        {
            var result = _colorDal.Get(c => c.Id == color.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _colorDal.Update(color);

            return new SuccessResult();
        }
    }
}
