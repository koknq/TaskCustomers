using DataAccessLayer.ContextManager;
using DataAccessLayer.Models;

namespace DataAccessLayer.Managers
{
    public class CustomerManager : ContextManager<Customer> , ICustomerManager
    {
        public CustomerManager(MyContext context) : base (context)
        {

        }
    }
}
