using SignalRChat.Core.Models;
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
    public interface IUserService
    {
        StatusModel<CtIdentityUser> LoginUser(string authName, string password);
        StatusModel<IList<User>> GetUserList(Expression<Func<User, bool>> filter);
        StatusModel<User> GetUser(Expression<Func<User, bool>> filter);

        StatusModel<User> Get(Expression<Func<User, bool>> filter);

        StatusModel<IList<User>> GetList(Expression<Func<User, bool>> filter);

        StatusModel<User> Add(User entity);

        StatusModel<User> Update(User entity);

        StatusModel<User> Delete(Expression<Func<User, bool>> filter);

    }
}
