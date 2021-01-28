using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Entities
{
    public class Admin:Person
    {
        public List<Person> Admins { get; set; }
    }
}
