using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Business.Utilities.Constants;
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
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();

            return new SuccessDataResult<List<Color>>(result, Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(c => c.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }

            return new SuccessDataResult<Color>(result, Messages.ThereIsAColor);
        }

        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExistsOfColorName(color.Name));

            if (result != null)
            {
                return result;
            }

            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorInsertionSuccess); 
        }

        public IResult Delete(Color color)
        {
            var result = BusinessRules.Run(CheckIfExistsOfColor(color.Id));

            if (result != null)
            {
                return result;
            }

            _colorDal.Delete(color);

            return new SuccessResult(Messages.ColorDeletedSuccess);
        }

        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckIfExistsOfColor(color.Id));

            if (result != null)
            {
                return result;
            }

            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorUpdatedSuccess);
        }

        private IResult CheckIfExistsOfColor(int colorId)
        {
            var result = _colorDal.Get(c => c.Id == colorId);

            if (result == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyExistsOfColorName(string colorName)
        {
            var result = _colorDal.Get(c => c.Name == colorName);

            if (result != null)
            {
                return new ErrorResult(Messages.ColorNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
