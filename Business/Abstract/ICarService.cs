using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByColorId(int Id);
        List<Car> GetByDailyPrice(decimal min,decimal max);
    }
}
