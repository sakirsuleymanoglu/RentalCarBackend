using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer entity)
        {
            _customerDal.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public Customer Get(int id)
        {
            return _customerDal.Get(p => p.Id == id);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
