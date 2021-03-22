using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RentalCar.Core.Entities;
using RentalCar.Core.Utilities.Results;

namespace RentalCar.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
