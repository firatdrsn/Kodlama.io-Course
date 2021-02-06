using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Marka giriniz");
            Brand brand = new Brand();
            brand.BrandName = Console.ReadLine();
            brandManager.Add(brand);
            Console.WriteLine("\nMarkalar");
            foreach (var itemBrand in brandManager.GetAll())
            {
                Console.WriteLine(itemBrand.BrandName);
            } 
            Console.WriteLine("\nRenk giriniz");
            Color color = new Color();
            color.ColorName = Console.ReadLine();
            colorManager.Add(color);
            Console.WriteLine("\nRenkler");
            foreach (var itemColor in colorManager.GetAll())
            {
                Console.WriteLine(itemColor.ColorName);
            }
            Console.WriteLine("\nYeni araç bilgilerini giriniz. Eklenen marka ve renk bilgisi otomatik seçildi");
            Car car = new Car();
            car.BrandId = brand.Id;
            car.ColorId = color.Id;
            Console.WriteLine("Günlük ücretini giriniz");
            car.DailyPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Model yılını giriniz");
            car.ModelYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Araçla ilgili açıklama giriniz");
            car.Description = Console.ReadLine();
            carManager.Add(car);
            Console.WriteLine("Ekli araçlar listesi");
            ListCar(carManager);
            Console.WriteLine("\n"+brand.BrandName+" markasına göre sıralama");
            foreach (var carByBrand in carManager.GetCarsByBrandId(brand.Id))
            {
                Console.WriteLine(carByBrand.Description + " - " + carByBrand.ModelYear + " - " + carByBrand.DailyPrice + "\n");
            }
            Console.WriteLine("\n" + color.ColorName+" rengine göre sıralama");
            foreach (var carByBrand in carManager.GetCarsByColorId(color.Id))
            {
                Console.WriteLine(carByBrand.Description + " - " + carByBrand.ModelYear + " - " + carByBrand.DailyPrice + "\n");
            }

        }

        private static void ListCar(CarManager carManager)
        {
            foreach (var carList in carManager.GetAll())
            {
                Console.WriteLine(carList.Id + " - " + carList.Description + " - " + carList.ModelYear + " - " + carList.DailyPrice+"\n");
            }
        }
    }
}
