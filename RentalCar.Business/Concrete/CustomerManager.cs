using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Business.Abstract;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Customer>>();
            }

            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Customer>();
            }

            return new SuccessDataResult<Customer>(result);
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            var result = _customerDal.Get(c => c.Id == customer.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _customerDal.Delete(customer);

            return new SuccessResult();
        }

        public IResult Update(Customer customer)
        {
            var result = _customerDal.Get(c => c.Id == customer.Id);

            if (result == null)
            {
                return new ErrorResult();
            }

            _customerDal.Update(customer);

            return new SuccessResult();
        }
    }
}
