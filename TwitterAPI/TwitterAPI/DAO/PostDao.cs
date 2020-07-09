using System.Collections.Generic;
using TwitterAPI.Models;
using System.Linq;

namespace TwitterAPI.DAO
{
    /// <summary>
    /// Database access object for getting and inserting post data.
    /// </summary>
    public class PostDao : IDAO<Post>
    {
        private readonly IDAO<User> UserDao;

        private static List<Post> Posts;

        public PostDao(IDAO<User> userDao)
        {
            this.UserDao = userDao;

            Posts = new List<Post>
            {
                new Post {
                    Id = 1,
                    Header = ".NET Core",
                    Body = "Still most trending server tech !",
                    IsPrivate = false,
                    Owner = this.UserDao.Get().Where(u => u.Id == 1).FirstOrDefault()
                },
                new Post {
                    Id = 2,
                    Header = "Front-end trends",
                    Body = "Angular holds the first spot among web technologies.",
                    IsPrivate = false,
                    Hasthtags = new List<string> { "web", "techologie" },
                    Owner = this.UserDao.Get().Where(u => u.Id == 1).FirstOrDefault()
                },
                new Post {
                    Id = 3,
                    Header = "Baby care",
                    Body = "New bornes should drink anything but breast milk",
                    IsPrivate = false,
                    Hasthtags = new List<string> { "baby", "mother" },
                    Owner = this.UserDao.Get().Where(u => u.Id == 2).FirstOrDefault()
                },
                new Post {
                    Id = 4,
                    Header = "Holiday time !",
                    Body = "Antalya is the best holiday place for now in Turkey !",
                    IsPrivate = false,
                    Hasthtags = new List<string> { "holiday" },
                    Owner = this.UserDao.Get().Where(u => u.Id == 3).FirstOrDefault()
                }
            };
        }

        public IEnumerable<Post> Get()
        {
            return Posts;
        }

        public Post Get(int id)
        {
            return Posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Post post)
        {
            Posts.Add(post);
        }
    }
}
