using DataAccessLayer.ContextManager;
using DataAccessLayer.Models;

namespace DataAccessLayer.Managers
{
    public interface ICustomerManager : IContextManager<Customer>
    {
    }
}
