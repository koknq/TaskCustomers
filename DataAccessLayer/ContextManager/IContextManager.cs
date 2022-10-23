using System.Collections.Generic;

namespace DataAccessLayer.ContextManager
{
    public interface IContextManager<T> where T : class
    {
        void Add(T entity);
        void Remove(string egn);
        void Update(T entity);
        T Find(int id);
        int Count();
        IEnumerable<T> GetAll();
    }
}
