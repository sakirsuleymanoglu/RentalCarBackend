using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using RentalCar.Business.Abstract;
using RentalCar.Business.ValidationRules.FluentValidation;
using RentalCar.Core.Business;
using RentalCar.Core.CrossCuttingCorcerns.Validation.FluentValidation;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Brand>>();
            }

            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(b => b.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Brand>();
            }

            return new SuccessDataResult<Brand>(result);
        }

        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);

            var result = BusinessRules.Run(CheckExistOfBrandName(brand.Name));

            if (result != null)
            {
                return new ErrorResult();
            }

            _brandDal.Add(brand);

            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.Run(CheckExistOfBrand(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Delete(brand);

            return new SuccessResult();
        }

        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(CheckExistOfBrand(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);

            return new SuccessResult();
        }

        private IResult CheckExistOfBrand(int brandId)
        {
            var result = _brandDal.Get(b => b.Id == brandId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckExistOfBrandName(string brandName)
        {
            var result = _brandDal.Get(b => b.Name == brandName);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
