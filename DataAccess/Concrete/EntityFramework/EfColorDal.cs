using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var addColor = rentCarContext.Entry(entity);
                addColor.State = EntityState.Added;
                rentCarContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var deleteColor = rentCarContext.Entry(entity);
                deleteColor.State = EntityState.Deleted;
                rentCarContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                return rentCarContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                return filter == null ? rentCarContext.Set<Color>().ToList() :
                    rentCarContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (RentCarContext rentCarContext = new RentCarContext())
            {
                var updateColor = rentCarContext.Entry(entity);
                updateColor.State = EntityState.Modified;
                rentCarContext.SaveChanges();
            }
        }
    }
}
