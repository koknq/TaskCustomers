using DataAccessLayer.ContextManager;
using DataAccessLayer.Models;

namespace DataAccessLayer.Managers
{
    public class EmailManager : ContextManager<Email>, IEmailManager
    {
        public EmailManager(MyContext context) : base (context)
        {

        }
    }
}
