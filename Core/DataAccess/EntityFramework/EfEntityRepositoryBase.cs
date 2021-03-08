using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext reCapDBContext = new TContext())
            {
                var addedEntity = reCapDBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDBContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapDBContext = new TContext())
            {
                var deletedEntity = reCapDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDBContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapDBContext = new TContext())
            {
                return reCapDBContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext reCapDBContext = new TContext())
            {
                return filter == null
                    ? reCapDBContext.Set<TEntity>().ToList()
                    : reCapDBContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext reCapDBContext = new TContext())
            {
                var updatedEntity = reCapDBContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapDBContext.SaveChanges();
            }
        }
    }
}
