using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService  
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)//ConsoleUI'da CarManager new yapıldığı anda burası çalışır(constructor)
        {                                //Böylece oluşturmuş olduğum InMemoryCarDal veritabanına bağımlı olmam
            _CarDal = carDal;
        }

        public List<Car> GetAll()//İş sınıfı başka sınıfları newlemez yoksa bağımlı olur
        {
            return _CarDal.GetAll();
        }
    }
}
