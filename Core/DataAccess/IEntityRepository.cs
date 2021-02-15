using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic Constraint
    //class : referans tip
    //IEntity : T, IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()//IEntity new'lenemediği için sadece onu implemente eden nesneler geçerli olur
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//Bu Metod ürünlerin hepsini listele anlamına gelir, filtreleme şart değildir
        T Get(Expression<Func<T, bool>> filter);//Burada ise filtreleme yaparız ve ürünler o filtreye göre sıralanır
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
