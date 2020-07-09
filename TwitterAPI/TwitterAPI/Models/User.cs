using System;
using System.Collections.Generic;

namespace TwitterAPI.Models
{
    public class User
    {
        public User()
        {
            var randomNumberGenerator = new Random();
            this.Id = randomNumberGenerator.Next(1, 1000);
        }

        public int Id { get; set; }

        public string EMail { get; set; }

        public string Password { get; set; }

        public List<int> Following { get; set; }
    }
}
