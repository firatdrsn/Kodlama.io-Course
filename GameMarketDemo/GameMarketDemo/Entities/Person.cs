using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long NationalityId { get; set; }
        public List<Game> Games { get; set; }
    }
}
