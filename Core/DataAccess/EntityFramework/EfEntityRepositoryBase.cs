using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDispossable pattern implementation of c#
            using (TContext context = new TContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var addedEntity = context.Entry(entity);//referansı tutar
                addedEntity.State = EntityState.Added;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var deletedEntity = context.Entry(entity);//referansı tutar
                deletedEntity.State = EntityState.Deleted;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity , bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var updatedEntity = context.Entry(entity);//referansı tutar
                updatedEntity.State = EntityState.Modified;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
    }
}
