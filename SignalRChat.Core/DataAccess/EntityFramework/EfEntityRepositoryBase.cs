using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Core.DataAccess;
using SignalRChat.Core.Entities;

namespace School.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity, TContext>
        : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        protected abstract List<TEntity> GetList(Expression<Func<TEntity,
            bool>> filter, TContext context);

        protected abstract TEntity Get(TEntity entity, TContext context);

        protected abstract TEntity Get(Expression<Func<TEntity, bool>> filter, TContext context);

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);

                addedEntity.State = EntityState.Added;

                context.SaveChanges();

                return addedEntity.Entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();

                return updatedEntity.Entity;
            }
        }

        public bool UpdateAll(IList<TEntity> entity)
        {
            using (var context = new TContext())
            {
                context.UpdateRange(entity);
                int updateRes = context.SaveChanges();
                return updateRes > 0;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var deletedEntity = Get(filter);

                Delete(deletedEntity);
            }
        }

        public TEntity Get(TEntity entity)
        {
            using (var context = new TContext())
            {
                return Get(entity, context);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return Get(filter, context);
            }
        }

        public List<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return GetList(filter, context);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

