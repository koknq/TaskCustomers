using DataAccessLayer.Managers;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext context;
        public UnitOfWork(MyContext context)
        {
            this.context = context;
            CustomerManager = new CustomerManager(context);
            EmailManager = new EmailManager(context);
            PhoneManager = new PhoneManager(context);
            AdressManager = new AdressManager(context);
        }

        public ICustomerManager CustomerManager { get; }

        public IEmailManager EmailManager { get; }

        public IPhoneManager PhoneManager { get; }

        public IAdressManager AdressManager { get; }
        public IHeaderManager HeaderManager { get; }

        public void Dispose()
        {
            context.Dispose();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
