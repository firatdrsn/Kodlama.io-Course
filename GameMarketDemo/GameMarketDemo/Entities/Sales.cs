using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public Person Buyer { get; set; }
        public Game Game { get; set; }
        public Campaign Campaign { get; set; }
        public double Amount { get; set; }
        public DateTime SellBy { get; set; }
    }
}
