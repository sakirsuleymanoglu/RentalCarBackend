using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Business.Utilities.Constants;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUserService _userService;

        public CustomerManager(ICustomerDal customerDal, IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();

            return new SuccessDataResult<List<Customer>>(result, Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<Customer>(result, Messages.ThereIsACustomer);
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerInsertionSuccess);
        }

        public IResult Delete(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfExistsOfCustomer(customer.Id));

            if (result != null)
            {
                return result;
            }

            _customerDal.Delete(customer);

            return new SuccessResult(Messages.CustomerDeletedSuccess);
        }

        public IResult Update(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfExistsOfCustomer(customer.Id));

            if (result != null)
            {
                return result;
            }

            _customerDal.Update(customer);

            return new SuccessResult(Messages.CustomerUpdatedSuccess);
        }

        private IResult CheckIfExistsOfCustomer(int customerId)
        {
            var result = _customerDal.Get(c => c.Id == customerId);

            if (result == null)
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }

            return new SuccessResult();
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            var result = BusinessRules.Run(CheckIfExistsOfUser(userId));

            if (result != null)
            {
                return new ErrorDataResult<Customer>(result.Message);
            }

            var customer = _customerDal.Get(c => c.UserId == userId);

            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<Customer>(customer, Messages.ThereIsACustomer);
        }

        private IResult CheckIfExistsOfUser(int userId)
        {
            var result = _userService.GetById(userId);

            if (result == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult();
        }
    }
}
