using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Business.Utilities.Constants;
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
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();

            return new SuccessDataResult<List<Rental>>(result, Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfExistsOfCar(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<Rental>>(result.Message);
            }

            var rentals = _rentalDal.GetAll(r => r.CarId == carId);

            return new SuccessDataResult<List<Rental>>(rentals, Messages.RentalsListed);
        }

        private IResult CheckIfExistsOfCar(int carId)
        {
            var result = _carService.GetById(carId);

            if (result == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            var result = BusinessRules.Run(CheckIfExistsCustomer(customerId));

            if (result != null)
            {
                return new ErrorDataResult<List<Rental>>(result.Message);
            }

            var rentals = _rentalDal.GetAll(r => r.CustomerId == customerId);

            return new SuccessDataResult<List<Rental>>(rentals, Messages.RentalsListed);
        }

        private IResult CheckIfExistsCustomer(int customerId)
        {
            var result = _customerService.GetById(customerId);

            if (result == null)
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }

            return new SuccessResult();
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }

            return new SuccessDataResult<Rental>(result, Messages.ThereIsARental);
        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExistsRentalDate(rental.RentDate, rental.ReturnDate));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalInsertionSuccess);
        }

        public IResult Delete(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfExistsOfRental(rental.Id));

            if (result != null)
            {
                return result;
            }
           
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeletedSuccess);
        }

        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfExistsOfRental(rental.Id));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdatedSuccess);
        }

        private IResult CheckIfExistsOfRental(int rentalId)
        {
            var result = _rentalDal.Get(r => r.Id == rentalId);

            if (result == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }

            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailsDto>> GetAllDetails()
        {
            var result = _rentalDal.GetAllDetailsOfRentals();

            return new SuccessDataResult<List<RentalDetailsDto>>(result, Messages.RentalsListed);
        }

        private IResult CheckIfAlreadyExistsRentalDate(DateTime rentDate, DateTime returnDate)
        {
            var result = _rentalDal.Get(r => r.RentDate == rentDate && r.ReturnDate == returnDate);

            if (result != null)
            {
                return new ErrorResult(Messages.RentalDateAlreadyExists);
            }

            return new SuccessResult();

        }
    }
}
