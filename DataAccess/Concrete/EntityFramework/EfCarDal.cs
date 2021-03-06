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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var addedEntity = reCapDBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDBContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var deletedEntity = reCapDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDBContext.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                return filter == null
                    ? reCapDBContext.Set<Car>().ToList()
                    : reCapDBContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var updatedEntity = reCapDBContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapDBContext.SaveChanges();
            }
        }
    }
}
