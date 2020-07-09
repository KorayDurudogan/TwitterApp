using System.Collections.Generic;

namespace TwitterAPI.DAO
{
    /// <summary>
    /// Database access object interface which implemented by data provider classes since app does not have a database.
    /// </summary>
    /// <typeparam name="T">Concrete type that used by DAO.</typeparam>
    public interface IDAO<T> where T : class
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Insert(T newMember);
    }
}
