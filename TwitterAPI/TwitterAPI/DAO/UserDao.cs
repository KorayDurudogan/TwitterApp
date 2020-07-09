using System.Collections.Generic;
using TwitterAPI.Models;
using System.Linq;

namespace TwitterAPI.DAO
{
    /// <summary>
    /// Database access object for getting and inserting user data.
    /// </summary>
    public class UserDao : IDAO<User>
    {
        private static List<User> Users;

        public UserDao()
        {
            Users = new List<User>
            {
                new User {
                    Id = 1,
                    EMail = "koray@gmail.com",
                    Password = "1234",
                    Following = new List<int>{ 2, 3 }
                },
                new User {
                    Id = 2,
                    EMail = "selin@gmail.com",
                    Password = "1234",
                    Following = new List<int>{ 1 }
                },
                new User {
                    Id = 3,
                    EMail = "merve@gmail.com",
                    Password = "1234",
                    Following = new List<int>{ 1, 2 }
                }
            };
        }

        public IEnumerable<User> Get()
        {
            return Users;
        }

        public User Get(int id)
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void Insert(User user)
        {
            Users.Add(user);
        }
    }
}
