using GameMarketDemo.Abstract;
using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Business
{
    public class GamerManager : BaseManager<Person>,IGamerService
    {
        IUserValidationService _userValidationService;
        Gamer gamerObject = new Gamer();
        public GamerManager(IUserValidationService userValidationService)
        {
            _userValidationService = userValidationService;
            gamerObject.Gamers = GetList();
        }
        public override void Add(Person gamer)
        {
            //if (_userValidationService.Validate(gamer))//Mernis kontrolü
            if (_userValidationService.TrueValidate(gamer))//Test
            {
                gamerObject.Gamers.Add(gamer);
                gamer.Games = new List<Game>();
                Console.WriteLine(gamer.Username+" kullanıcı adıyla sisteme kaydoldunuz\n");
            }
            else
            {
                Console.WriteLine("Böyle bir kişi bulunmuyor");
            }
        }
        public override void Update(Person gamer)
        {
            Console.WriteLine("Yeni isim değerini giriniz : ");
            gamer.FirstName = Console.ReadLine();
            Console.WriteLine("Yeni soyisim değerini giriniz : ");
            gamer.LastName = Console.ReadLine();
            Console.WriteLine("Yeni şifrenizi giriniz : ");
            gamer.Password = Console.ReadLine();
            Console.WriteLine(gamer.Username + " bilgileriniz güncellendi");
        }
        public override void GetListWrite()
        {
            Console.WriteLine("OYUNCULAR LİSTESİ");
            foreach (var gamer in gamerObject.Gamers)
            {
                Console.WriteLine("Id : {0} - Kullanıcı Adı : {1} - Adı : {2} - Soyadı : {3}", gamer.Id, gamer.Username, gamer.FirstName, gamer.LastName);
            }
            Console.WriteLine("");
        }
    }
}
