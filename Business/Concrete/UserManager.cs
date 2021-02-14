using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(int id)
        {
            return _userDal.Get(p => p.Id == id);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
