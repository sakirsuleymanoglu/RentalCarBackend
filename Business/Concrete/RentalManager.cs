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
                return new ErrorResult(Messages.AddRentalError);
            }
            _rentDal.Add(rental);   
            return new SuccessResult(Messages.AddRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            var result = _rentDal.Get(p=>p.Id == id);
            return new SuccessDataResult<Rental>(result);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IResult Update(Rental rental)
        {
            _rentDal.Update(rental);
            return new SuccessResult();
        }
    }
}
