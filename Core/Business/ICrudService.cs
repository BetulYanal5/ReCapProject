using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface ICrudService<T>
        where T:class,IEntity,new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        IDataResult<T> GetById(int Id);
        IDataResult<List<T>> GetAll();
    }
}
