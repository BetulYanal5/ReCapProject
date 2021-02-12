using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapContext context = new ReCapContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var addedEntity = context.Entry(entity);//referansı tutar
                addedEntity.State = EntityState.Added;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            using (ReCapContext context = new ReCapContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var updatedEntity = context.Entry(entity);//referansı tutar
                updatedEntity.State = EntityState.Modified;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }
    }
}
