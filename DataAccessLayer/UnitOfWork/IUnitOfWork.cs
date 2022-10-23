using System;
using DataAccessLayer.Managers;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public ICustomerManager CustomerManager { get; }
        public IEmailManager EmailManager { get; }
        public IPhoneManager PhoneManager { get; }
        public IAdressManager AdressManager { get; }
        public IHeaderManager HeaderManager { get; }
        public void SaveChanges();
        public void Dispose();
    }
}
