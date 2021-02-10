using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal//Car nesnemiz için veritabanı katmanında interface'ni oluşturduk ve operasyonları ekledik
    {
        List<Car> GetAll();
        List<Car> GetById(int Id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        
    }
}
