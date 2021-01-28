using GameMarketDemo.Business;
using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;

namespace GameMarketDemo
{
    class Program
    {
        static GamerManager gamerManager = new GamerManager(new PersonValidationManager());
        static GameManager gameManager = new GameManager();
        static CampaignManager campaignManager = new CampaignManager();
        static Admin admin = new Admin();
        static Gamer gamer = new Gamer();
        static Person person = new Person();
        static int gameId = 1;
        static int gamerId = 1;
        static int campaignId = 1;
        static void Main(string[] args)
        {
            TestValuesMethod();
            int secim = 1;
            while (secim != 0)
            {
                Console.WriteLine("Giriş yapmak için : 1'e basın \nKayıt olmak için : 2'ye basın \nÇıkış yapmak için : 0'a basın");
                secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Kullanıcı adınızı giriniz : ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Şifrenizi giriniz : ");
                        string password = Console.ReadLine();
                        foreach (var _admin in admin.Admins)
                        {
                            if (username == _admin.Username && password == _admin.Password)
                            {
                                Console.WriteLine("\nADMİN PANELİ");
                                AdminScreen();
                            }
                        }
                        foreach (var _gamer in gamerManager.GetList())
                        {
                            if (username == _gamer.Username && password == _gamer.Password)
                            {
                                Console.WriteLine("\nKULLANICI PANELİ");
                                UserScreen(_gamer);
                                break;
                            }
                        }
                        break;
                    case 2:
                        Person person = new Person();
                        GamerAddMethod();
                        gamerId++;
                        break;
                    case 0:
                        Console.WriteLine("Programdan çıkılıyor");
                        break;
                }
            }
        }
        private static void TestValuesMethod()
        {
            admin.Admins = new List<Person>();
            Person adminPerson = new Person { Id = 1, Username = "drsn95", Password = "123456", FirstName = "FIRAT", LastName = "DURSUN", DateOfBirth = Convert.ToDateTime("1995.01.01"), NationalityId = 12345678911 };
            if (new PersonValidationManager().TrueValidate(adminPerson))
            {
                admin.Admins.Add(adminPerson);
            }
            else
            {
                Console.WriteLine("Admin eklenirken hata oluştu");
            }
            Person person2 = new Person { Id = 2, Username = "deneme1", Password = "123456", FirstName = "deneme1", LastName = "deneme1soyisim", DateOfBirth = Convert.ToDateTime("2000.01.01"), NationalityId = 12345678901 };
            Person person3 = new Person { Id = 3, Username = "deneme2", Password = "123456", FirstName = "deneme2", LastName = "deneme2soyisim", DateOfBirth = Convert.ToDateTime("2001.01.01"), NationalityId = 11111111111 };
            gamerManager.Add(person2);
            gamerManager.Add(person3);
            gamerManager.Delete(person3);
            gamerManager.GetListWrite();
            Game gta = new Game
            {
                Id = gameId,
                GameName = "Grand Theft Auto V",
                GamePrice = 250
            };
            gameManager.Add(gta);
            gameId++;
            gameManager.Add(new Game { Id = gameId, GameName = "Witcher 3", GamePrice = 50 });
            gameId++;
            gameManager.GetListWrite();
            Campaign campaign1 = new Campaign { Id = campaignId, CampaignName = "Kış kampanyası", Discount = 20, StartDate = DateTime.Now, EndDate = Convert.ToDateTime("20.02.2021") };
            campaignManager.Add(campaign1);
            campaignId++;
            campaignManager.Add(new Campaign { Id = campaignId, CampaignName = "Yaz kampanyası", Discount = 25, StartDate = Convert.ToDateTime("20.06.2020"), EndDate = Convert.ToDateTime("20.08.2020") });
            campaignId++;
            campaignManager.GetListWrite();
            gameManager.Buy(gta, person2, campaign1);
            Console.WriteLine("Test Değerleri Sonu\n");
        }
        private static void AdminScreen()
        {
            int adminSecim = 1;
            while (adminSecim != 0)
            {
                Console.WriteLine("Oyun eklemek için : 1'e basın \nOyunları listelemek için 2'ye basın \nOyun güncellemek için 3'e basın \nKampanya eklemek için : 4'e basın \nKampanyaları listelemek için 5'e basın \nKampanya silmek için 6'ya basın \nKampanya güncellemek için 7'ye basın \nSatışlar listesini görmek için 8'e basın \nKayıtlı oyuncuları listelemek için 9'a basın \nÇıkış yapmak için : 0'a basın\n");
                adminSecim = int.Parse(Console.ReadLine());
                switch (adminSecim)
                {
                    case 1:
                        GameAddMethod();
                        break;
                    case 2:
                        gameManager.GetListWrite();
                        break;
                    case 3:
                        GameUpdateMethod();
                        break;
                    case 4:
                        CampaignAddMethod();
                        break;
                    case 5:
                        campaignManager.GetListWrite();
                        break;
                    case 6:
                        CampaignDeleteMethod();
                        break;
                    case 7:
                        CampaignUpdateMethod();
                        break;
                    case 8:
                        gameManager.GetListSalesWrite();
                        break;
                    case 9:
                        gamerManager.GetListWrite();
                        break;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor");
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız");
                        break;
                }
            }
        }
        private static void UserScreen(Person user)
        {
            int userSecim = 1;
            while (userSecim != 0)
            {
                Console.WriteLine("Oyun Listesini görmek için 1'e basın \nOyun satın almak için 2'ye basın \nMevcut kampanyaları görmek için 3'e basın \nBilgilerinizi güncellemek için 4'e basın \nHesabınızı silmek için 5'e basın \nSatın aldığınız oyunları görmek için 6'ya basın \nOturumdan çıkış yapmak için 0'a basın \n");
                userSecim = int.Parse(Console.ReadLine());
                switch (userSecim)
                {
                    case 1:
                        gameManager.GetListWrite();
                        break;
                    case 2:
                        GameBuyMethod(user);
                        break;
                    case 3:
                        campaignManager.GetCurrentListWrite();
                        break;
                    case 4:
                        gamerManager.Update(user);
                        Console.WriteLine("Tekrar giriş yapmalısınız");
                        userSecim = 0;
                        break;
                    case 5:
                        gamerManager.Delete(user);
                        Console.WriteLine("Hesabınız silindi");
                        userSecim = 0;
                        break;
                    case 6:
                        gameManager.GetListMyGames(user);
                        break;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor");
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız");
                        break;
                }
            }
        }
        private static void GameBuyMethod(Person user)
        {
            gameManager.GetListWrite();
            Console.WriteLine("Satın almak istediğiniz oyunun Id bilgisini yazınız");
            int buyGameId = Convert.ToInt32(Console.ReadLine());
            foreach (var game in gameManager.GetList())
            {
                Campaign campaign = campaignManager.CampaignControl(DateTime.Now);
                if (game.Id == buyGameId)
                {
                    Sales sale =gameManager.Buy(game, user, campaign);
                    if (campaign != null)
                    {
                        Console.WriteLine(game.GameName + " adlı oyunu " + sale.Amount.ToString() + " TL'ye " + campaign.CampaignName + " adlı kampanyadan faydalanarak %"+campaign.Discount+" indirimle satın aldınız\n");
                    }
                    else
                    {
                        Console.WriteLine(game.GameName + " adlı oyunu " + game.GamePrice + " TL'ye satın aldınız");
                    }
                    break;
                }
            }
        }
        private static void CampaignDeleteMethod()
        {
            campaignManager.GetListWrite();
            Console.WriteLine("Silinecek kampanyanın Id değerini giriniz");
            int campaignDeleteId = Convert.ToInt32(Console.ReadLine());
            foreach (var campaign in campaignManager.GetList())
            {
                if (campaign.Id == campaignDeleteId)
                {
                    string oldCampaignName = campaign.CampaignName;
                    campaignManager.Delete(campaign);
                    Console.WriteLine(oldCampaignName + " adlı kampanya silindi");
                    break;
                }
            }
        }
        private static void CampaignUpdateMethod()
        {
            campaignManager.GetListWrite();
            Console.WriteLine("Güncellenecek kampanyanın Id değerini giriniz");
            int campaignUpdateId = Convert.ToInt32(Console.ReadLine());
            foreach (var campaign in campaignManager.GetList())
            {
                if (campaign.Id == campaignUpdateId)
                {
                    campaignManager.Update(campaign);
                    Console.WriteLine(campaign.CampaignName + " adlı kampanya güncellendi");
                    break;
                }
            }
        }
        private static void GameUpdateMethod()
        {
            gameManager.GetListWrite();
            Console.WriteLine("Güncellenecek oyunun Id değerini giriniz");
            int gameUpdateId = Convert.ToInt32(Console.ReadLine());
            foreach (var game in gameManager.GetList())
            {
                if (game.Id == gameUpdateId)
                {
                    gameManager.Update(game);
                    Console.WriteLine(game.GameName + " adlı oyun güncellendi");
                    break;
                }
            }
        }
        public static void GameAddMethod()
        {
            Console.WriteLine("Eklenecek oyunun adını giriniz : ");
            string gameName = Console.ReadLine();
            Console.WriteLine("Oyunun fiyatını giriniz : ");
            int gamePrice = int.Parse(Console.ReadLine());
            Game game = new Game { Id = gameId, GameName = gameName, GamePrice = gamePrice };
            gameId++;
            gameManager.Add(game);
        }
        public static void CampaignAddMethod()
        {
            Console.WriteLine("Eklenecek kampanyanın adını giriniz : ");
            string campaignName = Console.ReadLine();
            Console.WriteLine("İndirim oranını giriniz : ");
            double discountPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Kampanya başlangıç tarihini giriniz : ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Kampanya bitiş tarihini giriniz : ");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());
            Campaign campaign = new Campaign { Id = campaignId, CampaignName = campaignName, Discount = discountPrice, StartDate = startDate, EndDate = endDate };
            campaignId++;
            campaignManager.Add(campaign);
        }
        private static void GamerAddMethod()
        {
            Person person = new Person();
            person.Id = gamerId;
            Console.WriteLine("Kullanıcı adınızı giriniz : ");
            person.Username = Console.ReadLine();
            Console.WriteLine("Şifrenizi giriniz : ");
            person.Password = Console.ReadLine();
            Console.WriteLine("Adınızı giriniz : ");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Soyadınızı giriniz : ");
            person.LastName = Console.ReadLine();
            Console.WriteLine("TC kimlik numaranızı giriniz : ");
            person.NationalityId = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Doğum tarihinizi giriniz : ");
            person.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            gamerManager.Add(person);
        }
    }
}
