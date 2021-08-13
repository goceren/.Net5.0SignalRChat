using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Context
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        //static BaseContext()
        //{
        //    Database.SetInitializer<TContext>(null);
        //}
        protected BaseContext(/*ICreateConnString _connectionString*/) : base()
        {
            //base.Configuration.LazyLoadingEnabled = false;
        }
    }
}
