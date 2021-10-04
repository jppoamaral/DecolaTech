using System.Collections.Generic;

namespace WatchList.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T returnById(int id);
        void Insert(T obj);
        void Remove(int id);
        void Update(int id, T obj);
        int nextId();
    }
}