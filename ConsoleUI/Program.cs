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
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            foreach (var c in carManager.GetByDailyPrice(100, 110))
            {
                Console.WriteLine(c.Description + " " + c.DailyPrice);
            }
            Console.WriteLine("Brand Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Description : ");
            string description = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            int modelYear = Convert.ToInt32(Console.ReadLine());

            Car addCar = new Car { BrandId = brandId, ColorId = colorId, DailyPrice = dailyPrice, Description = description, ModelYear = modelYear };
            carManager.Add(addCar);
        }
           
        
    }
}
