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
            //IDispossable pattern implementation of c#
            using (ReCapContext context=new ReCapContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var addedEntity = context.Entry(entity);//referansı tutar
                addedEntity.State = EntityState.Added;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context = new ReCapContext())//using içine yazdığımız nesneler using bitince garbage collector'u çağırır ve beni bellekten at der
            {
                var deletedEntity = context.Entry(entity);//referansı tutar
                deletedEntity.State = EntityState.Deleted;//işlemi belirler
                context.SaveChanges();//işlem gerçekleştirilir
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
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
