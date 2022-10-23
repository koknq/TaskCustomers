using DataAccessLayer.ContextManager;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Managers
{
    public class HeaderManager : ContextManager<Header>,IHeaderManager
    {
        public HeaderManager(MyContext context) : base(context)
        {

        }
    }
}
