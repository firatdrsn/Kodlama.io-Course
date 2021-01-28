using GameMarketDemo.Abstract;
using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Business
{
    public class GameManager : BaseManager<Game>, IGameService
    {
        Sales sale;
        public List<Sales> saleList = new List<Sales>();
        public List<Game> gameList = new List<Game>();
        int saleId = 1;
        public Sales Buy(Game game, Person gamer, Campaign campaign)
        {
            double oldGamePrice=game.GamePrice;
            gameList = gamer.Games;
            sale = new Sales();
            if (campaign != null)
            {
                game.GamePrice = game.GamePrice - ((game.GamePrice * campaign.Discount)/100);
                sale.Amount = game.GamePrice;
            }
            else
            {
                game.GamePrice = game.GamePrice;
                sale.Amount = game.GamePrice;
            }
            sale.Id = saleId;
            sale.Game = game;
            sale.Buyer = gamer;
            sale.Campaign = campaign;
            sale.SellBy = DateTime.Now;
            saleList.Add(sale);
            saleId++;
            gamer.Games.Add(game);
            game.GamePrice = oldGamePrice;
            return sale;
        }
        public override void GetListWrite()
        {
            Console.WriteLine("OYUNLAR LİSTESİ");
            foreach (var game in GetList())
            {
                Console.WriteLine("Id : {0} - Oyunun Adı : {1} - Fiyatı : {2}",game.Id,game.GameName,game.GamePrice);
            }
            Console.WriteLine("");
        }
        public override void Update(Game manager)
        {
            Console.WriteLine(manager.GameName+" Oyununun yeni fiyatını giriniz : ");
            manager.GamePrice= Convert.ToDouble(Console.ReadLine());
        }
        public List<Sales> GetListSales()
        {
            return saleList;
        }
        public void GetListSalesWrite()
        {
            Console.WriteLine("SATIŞLAR LİSTESİ");
            foreach (var sale in GetListSales())
            {
                Console.WriteLine("Id : {0} - Oyunun Adı : {1} - Satın alan kişi : {2} - Satın alma tarihi : {3} - Ödediği tutar : {4} TL", sale.Id, sale.Game.GameName, sale.Buyer.Username, sale.SellBy.ToShortDateString(), sale.Amount);
            }
            Console.WriteLine("");
        }

        public void GetListMyGames(Person person)
        {
            Console.WriteLine("Satın Aldığım Oyunlar");
            foreach (var game in person.Games)
            {
                Console.WriteLine("Oyunun Adı : {0} - Güncel Fiyatı {1}",game.GameName,game.GamePrice);
            }
            Console.WriteLine("");
        }
    }
}
