using TwitterAPI.Models;

namespace TwitterAPI.DAO
{
    /// <summary>
    /// Concrete class for contact features like follow/unfollow.
    /// </summary>
    public class Contact : IContact
    {
        //User that makes follow/unfollow.
        private User User;

        public Contact(User user)
        {
            this.User = user;
        }

        public void Follow(int userId)
        {
            this.User.Following.Add(userId);
        }

        public void Unfollow(int userId)
        {
            this.User.Following.Remove(userId);
        }
    }
}
