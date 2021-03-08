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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var addedEntity = reCapDBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDBContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var deletedEntity = reCapDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDBContext.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                return reCapDBContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                return filter == null
                    ? reCapDBContext.Set<Brand>().ToList()
                    : reCapDBContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
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
