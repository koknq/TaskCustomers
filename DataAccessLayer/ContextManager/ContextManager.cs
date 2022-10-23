using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer.ContextManager
{
    public class ContextManager<T> : IContextManager<T> where T : class
    {
        public MyContext Context { get; set; }
        public ContextManager(MyContext context)
        {
            this.Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Remove(string egn)
        {
            Customer customer = Context.Customers.Where(x => x.EGN == egn).FirstOrDefault();
            Context.Customers.Remove(customer);
        }
        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
        public T Find(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public int Count()
        {
            return Context.Set<T>().Count();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

    }
}
