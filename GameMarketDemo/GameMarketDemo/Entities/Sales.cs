using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public Gamer Buyer { get; set; }
        public Game Game { get; set; }
        public DateTime SellBy { get; set; }
    }
}
