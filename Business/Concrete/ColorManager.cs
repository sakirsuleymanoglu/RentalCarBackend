using Business.Abstract;
using Business.Constants;
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
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.SuccessAddColor);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.SuccessDeleteColor);
        }

        public IDataResult<Color> Get(int id)
        {
            var result = _colorDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Color>(result, Messages.ErrorGetColorById);
            }
            return new SuccessDataResult<Color>(result, Messages.SuccessGetColorById);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Color>>(result, Messages.ErrorListColors);
            }
            return new SuccessDataResult<List<Color>>(result, Messages.SuccessListColors);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.SuccessUpdateColor);
        }
    }
}
