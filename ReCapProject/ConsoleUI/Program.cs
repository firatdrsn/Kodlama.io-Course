using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            ListCar(carManager);
            Console.WriteLine("Yeni araç bilgilerini giriniz");
            Car car = new Car();
            Console.WriteLine("Id giriniz");
            car.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Brand Id giriniz");
            car.BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Color Id giriniz");
            car.ColorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Günlük ücretini giriniz");
            car.DailyPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Model yılını giriniz");
            car.ModelYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Araçla ilgili açıklama giriniz");
            car.Description = Console.ReadLine();
            carManager.Add(car);
            ListCar(carManager);

            Car updateCar = new Car();
            Console.WriteLine("Güncellenecek aracın id değerini giriniz");
            updateCar.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Brand Id giriniz");
            updateCar.BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Color Id giriniz");
            updateCar.ColorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Günlük ücretini giriniz");
            updateCar.DailyPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Model yılını giriniz");
            updateCar.ModelYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Araçla ilgili açıklama giriniz");
            updateCar.Description = Console.ReadLine();
            carManager.Update(updateCar);
            ListCar(carManager);

            Car deleteCar = new Car();
            Console.WriteLine("Silinecek aracın id değerini giriniz");
            deleteCar.Id = int.Parse(Console.ReadLine());
            carManager.Delete(deleteCar);
            ListCar(carManager);

        }

        private static void ListCar(CarManager carManager)
        {
            foreach (var carList in carManager.GetAll())
            {
                Console.WriteLine(carList.Id + " - " + carList.Description + " - Marka Id= " + carList.BrandId + " - Renk Id= " + carList.ColorId + " - " + carList.ModelYear + " - " + carList.DailyPrice);
            }
        }
    }
}
