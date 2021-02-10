using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;//Global değişken
        public InMemoryCarDal()
        {
            _cars = new List<Car> {//Global liste değişkenine verilerimizi atadık
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=150,Description="Audi A3 Dizel Otomatik"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2010,DailyPrice=70,Description="Mini Cooper"},
                new Car{Id=3,BrandId=3,ColorId=3,ModelYear=2010,DailyPrice=100,Description="BMW 3.20"},
                new Car{Id=4,BrandId=4,ColorId=4,ModelYear=2013,DailyPrice=85,Description="Fiat Doblo"},
                new Car{Id=5,BrandId=5,ColorId=5,ModelYear=2021,DailyPrice=210,Description="Wolksvagen Passat Dizel Otomatik"}
            };
        }
        public void Add(Car car)//Arayüzden ,business a gelen veriler burada veritabanına eklenir
        {
            _cars.Add(car);//Kullanıcının e-ticaret sistemine yeni bir ürün eklediğini düşünün
        }                  //Yeni ürün eklemek istediğinde ürünün özellikleri girer ve ekle butonuna tıklar
                           //İşte burada ekle butonu ile gelen yeni ürün veritabanına eklenir
        public void Delete(Car car)
        {
            Car carToDelete; //Linq ile kullanıcıdan gelen silinmek istenen ürünün Id'si veritabanında hangi ürünün Id'sine eşitse bulunur ve silinir
            carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);//Lambda =>
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()//veritabanı döndürülür,listelenir
        {
            return _cars;
        }

        public List<Car> GetById(int Id)//Buranın kategori olduğunu düşünelim kullanıcı sitede hangi kategoriye tıklarsa
        {                               //O kategorinin Id'si bulunur ve o kategorideki tüm ürünler listelenir
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)//Ekrandan gelen data
        {
           Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);//Kullanıcının güncellemek istediği veriyi bulur ve yeni verileri atar
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;//Örneğin burada kullanıcıdan gelen(car.ModelYear) model yılı bilgisini veritabanımdaki ModelYear'a atarım böylece güncellemiş olurum 
        }
    }
}
