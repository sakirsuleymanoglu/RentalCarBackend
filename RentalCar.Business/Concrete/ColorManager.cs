using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Business.ValidationRules.FluentValidation;
using RentalCar.Core.Aspects.Autofac.Validation;
using RentalCar.Core.Business;
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

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckIfExistOfColorName(color.Name));

            if (result != null)
            {
                return result;
            }

            _colorDal.Add(color);

            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            var result = BusinessRules.Run(CheckIfExistOfColor(color.Id));

            if (result != null)
            {
                return result;
            }

            _colorDal.Delete(color);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckIfExistOfColor(color.Id));

            if (result != null)
            {
                return result;
            }

            _colorDal.Update(color);

            return new SuccessResult();
        }

        private IResult CheckIfExistOfColor(int colorId)
        {
            var result = _colorDal.Get(c => c.Id == colorId);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistOfColorName(string colorName)
        {
            var result = _colorDal.Get(c => c.Name == colorName);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
