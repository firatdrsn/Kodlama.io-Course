using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Entities
{
    public class Gamer:Person
    {
        public List<Game> Games { get; set; }
    }
}
