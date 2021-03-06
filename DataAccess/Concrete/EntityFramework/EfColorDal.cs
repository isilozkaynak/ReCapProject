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
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var addedEntity = reCapDBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDBContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                var deletedEntity = reCapDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDBContext.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapDBContext reCapDBContext=new ReCapDBContext())
            {
                return filter == null
                    ? reCapDBContext.Set<Color>().ToList()
                    : reCapDBContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
