using SignalRChat.Core.DataAccess;
using SignalRChat.Entity.ComplexTypes;
using SignalRChat.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        CtIdentityUser LoginUser(string authName, string password);
        IList<User> GetUserList(Expression<Func<User, bool>> filter);
        User GetUser(Expression<Func<User, bool>> filter);
    }
}
