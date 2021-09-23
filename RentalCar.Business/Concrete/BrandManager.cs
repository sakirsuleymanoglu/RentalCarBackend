using System.Collections.Generic;
using RentalCar.Business.Abstract;
using RentalCar.Business.Utilities.Constants;
using RentalCar.Core.Business;
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

            return new SuccessDataResult<List<Brand>>(result, Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(b => b.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }

            return new SuccessDataResult<Brand>(result, Messages.ThereIsABrand);
        }

        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExistsOfBrandName(brand.Name));

            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandInsertionSuccess);
        }

        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfExistsOfBrand(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Delete(brand);

            return new SuccessResult(Messages.BrandDeletedSuccess);
        }

        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfExistsOfBrand(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdatedSuccess);
        }

        private IResult CheckIfExistsOfBrand(int brandId)
        {
            var result = _brandDal.Get(b => b.Id == brandId);

            if (result == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyExistsOfBrandName(string brandName)
        {
            var result = _brandDal.Get(b => b.Name == brandName);

            if (result != null)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
