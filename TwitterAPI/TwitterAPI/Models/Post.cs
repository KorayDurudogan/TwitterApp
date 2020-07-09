using System;
using System.Collections.Generic;

namespace TwitterAPI.Models
{
    public class Post
    {
        public Post()
        {
            var randomNumberGenerator = new Random();
            this.Id = randomNumberGenerator.Next(1, 1000);
        }

        public int Id { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public bool IsPrivate { get; set; }

        public IEnumerable<string> Hasthtags { get; set; }

        public User Owner { get; set; }
    }
}
