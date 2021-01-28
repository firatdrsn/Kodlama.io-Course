using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Abstract
{
    public interface IGameService
    {
        Sales Buy(Game game,Person person,Campaign campaign);
        List<Sales> GetListSales();
        void GetListMyGames(Person person);
        void GetListSalesWrite();
    }
}
