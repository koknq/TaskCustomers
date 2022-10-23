using DataAccessLayer.ContextManager;
using DataAccessLayer.Models;

namespace DataAccessLayer.Managers
{
    public class AdressManager : ContextManager<Address>, IAdressManager
    {
        public AdressManager(MyContext context) : base (context)
        {

        }
    }
}
