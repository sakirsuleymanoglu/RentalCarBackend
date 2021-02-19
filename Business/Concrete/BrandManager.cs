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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 3)
            {
                return new ErrorResult(Messages.ErrorAddBrand);
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.SuccessAddBrand);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.SuccessDeleteBrand);
        }

        public IDataResult<Brand> Get(int id)
        {
            var result = _brandDal.Get(b => b.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.ErrorGetBrandById);
            }

            return new SuccessDataResult<Brand>(result, Messages.SuccessGetBrandById);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Brand>>(Messages.ErrorListBrands);
            }

            return new SuccessDataResult<List<Brand>>(result, Messages.SuccessListBrands);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccessResult(Messages.SuccessUpdateBrand);
        }
    }
}
