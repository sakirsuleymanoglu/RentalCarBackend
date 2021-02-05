using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var addBrand = rentCarContext.Entry(entity);
                addBrand.State = EntityState.Added;
                rentCarContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var deleteBrand = rentCarContext.Entry(entity);
                deleteBrand.State = EntityState.Deleted;
                rentCarContext.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                return rentCarContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                return filter == null ? rentCarContext.Set<Brand>().ToList() :
                    rentCarContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var updateBrand = rentCarContext.Entry(entity);
                updateBrand.State = EntityState.Modified;
                rentCarContext.SaveChanges();
            }
        }
    }
}
