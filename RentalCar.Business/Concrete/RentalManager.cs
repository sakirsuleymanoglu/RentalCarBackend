using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTOs;

namespace RentalCar.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();

            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);

            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            var result = _rentalDal.GetAll(r => r.CustomerId == customerId);

            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Rental>();
            }

            return new SuccessDataResult<Rental>(result);
        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfExistRentalDate(rental.RentDate, rental.ReturnDate));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);

            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _rentalDal.Delete(rental);

            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _rentalDal.Update(rental);

            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailsDto>> GetAllDetails()
        {
            var result = _rentalDal.GetAllDetailsOfRentals();

            return new SuccessDataResult<List<RentalDetailsDto>>(result);
        }

        private IResult CheckIfExistRentalDate(DateTime rentDate, DateTime returnDate)
        {
            var result = _rentalDal.Get(r => r.RentDate == rentDate && r.ReturnDate == returnDate);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();

        }
    }
}
