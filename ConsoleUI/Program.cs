using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}\t{car.ColorId}\t\t{car.CarName}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("Araç eklemek için 1'i tuşlayın");
            Console.WriteLine("Araç silmek için 2'yi tuşlayın");
            Console.WriteLine("Tüm markaları görmek için 3'ü tuşlayın");
            Console.WriteLine("Çıkış yapmak için 4'tuşlayın");
            int p = Convert.ToInt32(Console.ReadLine());
            while (p != 4)
            {
                switch (p)
                {
                    case 1:
                        AddCar(carManager);
                        break;
                    case 2:
                        DeleteCar(carManager);
                        break;
                    case 3:
                        BrandName(brandManager);
                        break;
                    case 5:
                        CarDetails(carManager);
                        break;
                }
                Console.WriteLine("Araç eklemek için 1'i tuşlayın");
                Console.WriteLine("Araç silmek için 2'yi tuşlayın");
                Console.WriteLine("Tüm markaları görmek için 3'ü tuşlayın");
                Console.WriteLine("Çıkış yapmak için 4'tuşlayın");
                Console.WriteLine("Araba özellikleri için 5' tuşlayın");
                p = Convert.ToInt32(Console.ReadLine());
            }

            //foreach (var c in carManager.GetByDailyPrice(100, 110))
            //{
            //    Console.WriteLine(c.Description + " " + c.DailyPrice);
            //}
            //AddCar(carManager);
            //DeleteCar(carManager);
            //BrandName();
            CarDetails(carManager);
        }

        private static void CarDetails(CarManager carManager)
        {
            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.CarName + " " + c.BrandName + " " + c.ColorName + " " + c.DailyPrice);
            }
        }

        private static void DeleteCar(CarManager carManager)
        {
            Console.WriteLine("Hangi aracı silmek istersiniz Id'sini girin");
            var x = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetById(x));
        }

        private static void BrandName(BrandManager brandManager)
        {
            Console.WriteLine("-----Brand Names-----");
           // BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var b in brandManager.GetAllBrands())
            {
                Console.WriteLine(b.BrandName);
            }
        }

        private static void AddCar(CarManager carManager)
        {
            Console.WriteLine("Brand Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Car Name");
            string carName = Console.ReadLine().ToString();

            Console.WriteLine("Daily Price: ");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Description : ");
            string description = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            int modelYear = Convert.ToInt32(Console.ReadLine());

            Car addCar = new Car { BrandId = brandId, ColorId = colorId, CarName=carName, DailyPrice = dailyPrice, Description = description, ModelYear = modelYear };
            carManager.Add(addCar);
        }

    }
}
