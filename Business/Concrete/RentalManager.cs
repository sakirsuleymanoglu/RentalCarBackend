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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentDal;

        public RentalManager(IRentalDal rentDal)
        {
            _rentDal = rentDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == DateTime.MinValue)
            {
                return new ErrorResult(Messages.ErrorAddRental);
            }
            _rentDal.Add(rental);
            return new SuccessResult(Messages.SuccessAddRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentDal.Delete(rental);
            return new SuccessResult(Messages.SuccessDeleteRental);
        }

        public IDataResult<Rental> Get(int id)
        {
            var result = _rentDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Rental>(result, Messages.ErrorGetRentalById);
            }
            return new SuccessDataResult<Rental>(result, Messages.SuccessGetRentalById);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Rental>>(result, Messages.ErrorListRentals);
            }
            return new SuccessDataResult<List<Rental>>(result, Messages.SuccessListRentals);
        }

        public IResult Update(Rental rental)
        {
            _rentDal.Update(rental);
            return new SuccessResult(Messages.SuccessUpdateRental);
        }
    }
}
