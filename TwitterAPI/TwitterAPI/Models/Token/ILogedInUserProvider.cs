namespace TwitterAPI.Models.Token
{
    public interface ILogedInUserProvider<T> where T : class
    {
        T GetLogedInUser();
    }
}
