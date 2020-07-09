namespace TwitterAPI.DAO
{
    /// <summary>
    /// Interface for contact features like follow/unfollow.
    /// </summary>
    public interface IContact
    {
        void Follow(int userId);

        void Unfollow(int userId);
    }
}
