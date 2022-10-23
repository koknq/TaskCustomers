using DataAccessLayer.ContextManager;
using DataAccessLayer.Models;

namespace DataAccessLayer.Managers
{
    public class PhoneManager : ContextManager<Phone> , IPhoneManager
    {
        public PhoneManager(MyContext context) : base(context)
        {

        }
    }
}
