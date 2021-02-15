﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public void Add(Car car)
        {
            if ((car.DailyPrice > 0)&&(car.CarName.Length>=2))
            {
               _CarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba fiyatı 0'dan düşük olmamalı ve araba açıklaması en az 2 karakterli olmalı");
            }
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()//İş sınıfı başka sınıfları newlemez yoksa bağımlı olur
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _CarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetById(int id)
        {
            return _CarDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _CarDal.GetAll(c => c.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _CarDal.GetAll(c => c.ColorId == Id);
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}
