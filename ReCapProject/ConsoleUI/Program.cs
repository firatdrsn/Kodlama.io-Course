using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Core.Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static CarManager carManager = new CarManager(new EfCarDal());
        static BrandManager brandManager = new BrandManager(new EfBrandDal());
        static ColorManager colorManager = new ColorManager(new EfColorDal());
        static UserManager userManager = new UserManager(new EfUserDal());
        static CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        static RentalManager rentalManager = new RentalManager(new EfRentalDal());
        static void Main(string[] args)
        {
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("Marka işlemleri için 1'e basınız\nRenk işlemleri için 2'ye basınız\nAraç işlemleri için 3'e basınız\nKullanıcı işlemleri için 4'e basınız\nŞirket işlemleri için 5'e basınız\nKiralama işlemleri için 6'ya basınız\nÇıkış yapmak için 0'a basınız");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        BrandMenu();
                        break;
                    case 2:
                        ColorMenu();
                        break;
                    case 3:
                        CarMenu();
                        break;
                    case 4:
                        //UserMenu();
                        break;
                    case 5:
                        CustomerMenu();
                        break;
                    case 6:
                        RentalMenu();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void BrandMenu()
        {
            int brandMenu = 1;
            while (brandMenu != 0)
            {
                Console.WriteLine("Marka eklemek için 1'e basınız\nMarka güncellemek için 2'ye basınız\nMarka silmek için 3'e basınız\nMarkaları listelemek için 4'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                brandMenu = int.Parse(Console.ReadLine());
                switch (brandMenu)
                {
                    case 1:
                        Console.WriteLine("Yeni Markayı giriniz");
                        Brand brand = new Brand();
                        brand.BrandName = Console.ReadLine();
                        //brandManager.Add(brand);
                        Console.WriteLine(brandManager.Add(brand).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz markanın Idsini giriniz");
                        BrandWriteList();
                        Brand updateToBrand = brandManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        if(updateToBrand==null)
                        {
                            Console.WriteLine("Geçersiz Id\n");
                            break;
                        }
                        Console.WriteLine("Güncel marka adını giriniz");
                        updateToBrand.BrandName = Console.ReadLine();
                        Console.WriteLine(brandManager.Update(updateToBrand).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz markanın Idsini giriniz");
                        BrandWriteList();
                        Brand deleteToBrand = brandManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        Console.WriteLine(brandManager.Delete(deleteToBrand).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nMarkalar");
                        BrandWriteList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }

        //private static void UserMenu()
        //{
        //    int userMenu = 1;
        //    while (userMenu != 0)
        //    {
        //        Console.WriteLine("Kullanıcı eklemek için 1'e basınız\nKullanıcı güncellemek için 2'ye basınız\nKullanıcı silmek için 3'e basınız\nKullanıcıları listelemek için 4'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
        //        userMenu = int.Parse(Console.ReadLine());
        //        switch (userMenu)
        //        {
        //            case 1:
        //                Console.WriteLine("Kullanıcı adını giriniz");
        //                User user = new User();
        //                user.UserName = Console.ReadLine();
        //                Console.WriteLine("Şifrenizi giriniz");
        //                user.Password = Console.ReadLine();
        //                Console.WriteLine("Adınızı giriniz");
        //                user.FirstName = Console.ReadLine();
        //                Console.WriteLine("Soyadınızı giriniz");
        //                user.LastName = Console.ReadLine();
        //                Console.WriteLine("E-mail adresinizi giriniz");
        //                user.Email = Console.ReadLine();
        //                Console.WriteLine(userManager.Add(user).Message);
        //                break;
        //            case 2:
        //                Console.WriteLine("Güncellemek istediğiniz kullanıcının Idsini giriniz");
        //                UserWriteList();
        //                User updateToUser = userManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
        //                if (updateToUser==null)
        //                {
        //                    Console.WriteLine("Gerçersiz Id");
        //                    break;
        //                }
        //                Console.WriteLine("Şifrenizi giriniz");
        //                updateToUser.Password = Console.ReadLine();
        //                Console.WriteLine("Adınızı giriniz");
        //                updateToUser.FirstName = Console.ReadLine();
        //                Console.WriteLine("Soyadınızı giriniz");
        //                updateToUser.LastName = Console.ReadLine();
        //                Console.WriteLine("E-mail adresinizi giriniz");
        //                updateToUser.Email = Console.ReadLine();
        //                Console.WriteLine(userManager.Update(updateToUser).Message);
        //                break;
        //            case 3:
        //                Console.WriteLine("Silmek istediğiniz kullanıcının Idsini giriniz");
        //                UserWriteList();
        //                User deleteToUser = userManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
        //                Console.WriteLine(userManager.Delete(deleteToUser).Message);
        //                break;
        //            case 4:
        //                Console.WriteLine("\nKullanıcılar");
        //                UserWriteList();
        //                break;
        //            case 0:
        //                break;
        //            default:
        //                Console.WriteLine("Hatalı bir seçim yaptınız");
        //                break;
        //        }
        //    }
        //}
        private static void CustomerMenu()
        {
            int customerMenu = 1;
            while (customerMenu != 0)
            {
                Console.WriteLine("Şirket eklemek için 1'e basınız\nŞirket güncellemek için 2'ye basınız\nŞirket silmek için 3'e basınız\nŞirketleri listelemek için 4'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                customerMenu = int.Parse(Console.ReadLine());
                switch (customerMenu)
                {
                    case 1:
                        UserWriteList();
                        Console.WriteLine("Şirketini yazacağınız kullanıcının Idsini yazınız");
                        Customer customer = new Customer();
                        int userId= Convert.ToInt32(Console.ReadLine());
                        if (userManager.GetById(userId).Data==null)
                        {
                            Console.WriteLine("Geçersiz kullanıcı idsi");
                            break;
                        }
                        customer.UserId = userManager.GetById(userId).Data.Id;
                        Console.WriteLine("Şirket adını giriniz");
                        customer.CompanyName = Console.ReadLine();
                        Console.WriteLine(customerManager.Add(customer).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz şirketin Idsini giriniz");
                        CustomerWriteList();
                        Customer updateToCustomer = customerManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        if (updateToCustomer==null)
                        {
                            Console.WriteLine("Geçersiz Id");
                            break;
                        }
                        Console.WriteLine("Yeni şirket adını giriniz");
                        updateToCustomer.CompanyName = Console.ReadLine();
                        Console.WriteLine(customerManager.Update(updateToCustomer).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz şirketin Idsini giriniz");
                        CustomerWriteList();
                        Customer deleteToCustomer = customerManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        Console.WriteLine(customerManager.Delete(deleteToCustomer).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nŞirketler");
                        CustomerWriteList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void RentalMenu()
        {
            int customerMenu = 1;
            while (customerMenu != 0)
            {
                Console.WriteLine("Araç kiralamak için 1'e basınız\nKiralanmış aracı teslim etmek için 2'ye basınız\nKiralamaları listelemek için 3'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                customerMenu = int.Parse(Console.ReadLine());
                switch (customerMenu)
                {
                    case 1:
                        CarWriteDetailList();
                        Console.WriteLine("Kiralanacak aracın Idsini yazınız");
                        int carId= Convert.ToInt32(Console.ReadLine());
                        CustomerWriteList();
                        Console.WriteLine("Kiralayacak şirketin ıdsini giriniz");
                        int customerId= Convert.ToInt32(Console.ReadLine());
                        if (!carManager.GetById(carId).Success || !customerManager.GetById(customerId).Success)
                        {
                            Console.WriteLine("Yanlış araç veya müşteri Idsi");
                            break;
                        }
                        Rental rental = new Rental();
                        rental.CustomerId = customerId;
                        rental.CarId = carId;
                        Console.WriteLine("Kiralama tarihini giriniz");
                        rental.RentDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine(rentalManager.Add(rental).Message);
                        break;
                    case 2:
                        UndeliveredCarsWriteList();
                        if (!rentalManager.GetUndeliveredCarsDetails().Success)
                        {
                            break;
                        }
                        Console.WriteLine("Teslim edilecek aracın Idsini giriniz");
                        Rental updateToRental = rentalManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        if (updateToRental==null)
                        {
                            Console.WriteLine("Geçersiz Id");
                            break;
                        }
                        Console.WriteLine("Teslim tarihini giriniz");
                        updateToRental.ReturnDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine(rentalManager.Update(updateToRental).Message);
                        break;
                    case 3:
                        Console.WriteLine("\nKiralama listesi");
                        RentalWriteList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void ColorMenu()
        {
            int colorMenu = 1;
            while (colorMenu != 0)
            {
                Console.WriteLine("Renk eklemek için 1'e basınız\nRenk güncellemek için 2'ye basınız\nRenk silmek için 3'e basınız\nRenkleri listelemek için 4'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                colorMenu = int.Parse(Console.ReadLine());
                switch (colorMenu)
                {
                    case 1:
                        Console.WriteLine("Yeni Renk giriniz");
                        Color color = new Color();
                        color.ColorName = Console.ReadLine();
                        Console.WriteLine(colorManager.Add(color).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz renk Idsini giriniz");
                        ColorWriteList();
                        Color updateToColor = colorManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        if (updateToColor==null)
                        {
                            Console.WriteLine("Geçersiz Id");
                            break;
                        }
                        Console.WriteLine("Güncel Renk bilgisini giriniz");
                        updateToColor.ColorName = Console.ReadLine();
                        Console.WriteLine(colorManager.Update(updateToColor).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz renk Idsini giriniz");
                        ColorWriteList();
                        Color deleteToColor = colorManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        Console.WriteLine(colorManager.Delete(deleteToColor).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nRenkler");
                        ColorWriteList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void CarMenu()
        {
            int carMenu = 1;
            while (carMenu != 0)
            {
                Console.WriteLine("Araç eklemek için 1'e basınız\nAraç güncellemek için 2'ye basınız\nAraç silmek için 3'e basınız\nAraçları listelemek için 4'e basınız\nAraçları markaya göre listelemek için 5'e basınız\nAraçları renge göre listelemek için 6'ya basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                carMenu = int.Parse(Console.ReadLine());
                switch (carMenu)
                {
                    case 1:
                        Car car = new Car();
                        Console.WriteLine("Araç adı giriniz");
                        car.CarName = Console.ReadLine();
                        Console.WriteLine("Marka Idsini giriniz");
                        car.BrandId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Renk Idsini giriniz");
                        car.ColorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Günlük ücretini giriniz");
                        car.DailyPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Model yılını giriniz");
                        car.ModelYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Araçla ilgili açıklama giriniz");
                        car.Description = Console.ReadLine();
                        Console.WriteLine(carManager.Add(car).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz aracın Idsini giriniz");
                        CarWriteList();
                        Car updateToCar = carManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        if (updateToCar==null)
                        {
                            Console.WriteLine("Geçersiz Id");
                            break;
                        }
                        Console.WriteLine("Güncel Araç adı giriniz");
                        updateToCar.CarName = Console.ReadLine();
                        Console.WriteLine("Güncel Marka Idsini giriniz");
                        updateToCar.BrandId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel Renk Idsini giriniz");
                        updateToCar.ColorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel ücretini giriniz");
                        updateToCar.DailyPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel Model yılını giriniz");
                        updateToCar.ModelYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel Araç açıklamasını giriniz");
                        updateToCar.Description = Console.ReadLine();
                        Console.WriteLine(carManager.Update(updateToCar).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz aracın Idsini giriniz");
                        CarWriteList();
                        Car deleteToCar = carManager.GetById(Convert.ToInt32(Console.ReadLine())).Data;
                        Console.WriteLine(carManager.Delete(deleteToCar).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nAraçlar");
                        CarWriteDetailList();
                        break;
                    case 5:
                        BrandWriteList();
                        Console.WriteLine("Markaya göre sıralama yapmak için marka Idsi giriniz");
                        int brandId = int.Parse(Console.ReadLine());
                        CarWriteByBrand(brandId);
                        break;
                    case 6:
                        ColorWriteList();
                        Console.WriteLine("Renklere göre sıralama yapmak için renk Idsini giriniz");
                        int colorId = int.Parse(Console.ReadLine());
                        CarWriteByColor(colorId);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void BrandWriteList()
        {
            try
            {
                foreach (var itemBrand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(itemBrand.Id + " - " + itemBrand.BrandName);
                }
            }
            catch
            {
                Console.WriteLine(brandManager.GetAll().Message);
            }
        }
        private static void CustomerWriteList()
        {
            try
            {
                foreach (var itemCustomer in customerManager.GetCustomerDetails().Data)
                {
                    Console.WriteLine(itemCustomer.Id + " - " +itemCustomer.UserName+" - "+itemCustomer.FirstName+" "+itemCustomer.LastName+" - "+ itemCustomer.CompanyName+" - "+itemCustomer.Email);
                }
            }
            catch
            {
                Console.WriteLine(customerManager.GetCustomerDetails().Message);
            }
        }
        private static void UserWriteList()
        {
            try
            {
                foreach (var itemUser in userManager.GetAll().Data)
                {
                    Console.WriteLine(itemUser.Id + " - " + itemUser.UserName+" - "+ itemUser.FirstName+" "+ itemUser.LastName+" - "+itemUser.Email);
                }
            }
            catch
            {
                Console.WriteLine(userManager.GetAll().Message);
            }
        }
        private static void ColorWriteList()
        {
            try
            {
                foreach (var itemBrand in colorManager.GetAll().Data)
                {
                    Console.WriteLine(itemBrand.Id + " - " + itemBrand.ColorName);
                }
            }
            catch
            {
                Console.WriteLine(colorManager.GetAll().Message);
            }
        }
        private static void CarWriteList()
        {
            try
            {
                foreach (var carList in carManager.GetAll().Data)
                {
                    Console.WriteLine(carList.Id + " - " + carList.CarName + " - " + carList.Description + " - " + carList.ModelYear + " - " + carList.DailyPrice + "\n");
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetAll().Message);
            }
        }
        private static void CarWriteDetailList()
        {
            try
            {
                foreach (var carDetail in carManager.GetAllCarsDetails().Data)
                {
                    Console.WriteLine(carDetail.CarId + " - " + carDetail.CarName + " - " + carDetail.BrandName + " - " + carDetail.ColorName + " - " + carDetail.DailyPrice+" - "+carDetail.Description);
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetAllCarsDetails().Message);
            }
        }

        private static void RentalWriteList()
        {
            try
            {
                foreach (var rentalDetail in rentalManager.GetRentalDetails().Data)
                {
                    Console.WriteLine(rentalDetail.RentalId+" - "+rentalDetail.CarName + " - " + rentalDetail.CompanyName + " - " + rentalDetail.FirstName + " " + rentalDetail.LastName + " - " + rentalDetail.RentDate+" - "+ rentalDetail.ReturnDate);
                }
            }
            catch
            {
                Console.WriteLine(rentalManager.GetRentalDetails().Message);
            }
        }
        private static void UndeliveredCarsWriteList()
        {
            try
            {
                foreach (var rentalDetail in rentalManager.GetUndeliveredCarsDetails().Data)
                {
                    Console.WriteLine(rentalDetail.RentalId + " - " + rentalDetail.CarName + " - " + rentalDetail.CompanyName + " - " + rentalDetail.FirstName + " " + rentalDetail.LastName + " - " + rentalDetail.RentDate + " - " + rentalDetail.ReturnDate);
                }
            }
            catch
            {
                Console.WriteLine(rentalManager.GetUndeliveredCarsDetails().Message);
            }
        }
        private static void CarWriteByColor(int colorId)
        {
            try
            {
                foreach (var carByColor in carManager.GetCarsByColorId(colorId).Data)
                {
                    Console.WriteLine(carByColor.CarName + " - " + carByColor.Description + " - " + carByColor.ModelYear + " - " + carByColor.DailyPrice + "\n");
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetCarsByColorId(colorId).Message);
            }
        }

        private static void CarWriteByBrand(int brandId)
        {
            try
            {
                foreach (var carByBrand in carManager.GetCarsByBrandId(brandId).Data)
                {
                    Console.WriteLine(carByBrand.CarName + " - " + carByBrand.Description + " - " + carByBrand.ModelYear + " - " + carByBrand.DailyPrice + "\n");
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetCarsByBrandId(brandId).Message);
            }
        }
    }
}
