﻿using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

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

        public IDataResult<Brand> Get(int id)
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
            _brandDal.Add(brand);

            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            var result = _brandDal.Get(b => b.Id == brand.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _brandDal.Delete(brand);

            return new SuccessResult();
        }

        public IResult Update(Brand brand)
        {
            var result = _brandDal.Get(b => b.Id == brand.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _brandDal.Update(brand);

            return new SuccessResult();
        }
    }
}