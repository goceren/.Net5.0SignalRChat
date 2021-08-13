using Microsoft.EntityFrameworkCore;
using School.Core.DataAccess.EntityFramework;
using SignalRChat.Core.Utilities;
using SignalRChat.Data.Abstract;
using SignalRChat.Data.Context;
using SignalRChat.Entity.ComplexTypes;
using SignalRChat.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, ApplicationDbContext>, IUserDal
    {
        public User GetUser(Expression<Func<User, bool>> filter)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Users
                        .Where(filter)
                        .Include(i => i.Messages).ThenInclude(i => i.Receiver)
                        .Include(i => i.Messages).ThenInclude(i => i.Sender)
                        .FirstOrDefault();

                return query;
            }

        }

        public IList<User> GetUserList(Expression<Func<User, bool>> filter)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Users.Where(filter).Include(i => i.Messages);

                return query.ToList();
            }
        }

        public CtIdentityUser LoginUser(string authName, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Users
                        .Where(i => (i.Username.Equals(authName) || i.Email.Equals(authName) || i.Phone.Equals(authName)) && i.Password.Equals(password))
                        .Include(i => i.Messages).ThenInclude(i => i.Receiver)
                        .Include(i => i.Messages).ThenInclude(i => i.Sender).Select(i => new CtIdentityUser()
                        {
                            Id = i.Id,
                            ChangedOn = i.ChangedOn,
                            Email = i.Email,
                            Phone = i.Phone,
                            State = i.State,
                            Username = i.Username,
                            WrongAttemptCount = i.WrongAttemptCount,
                            CreatedOn = i.CreatedOn,
                        });
                return query.FirstOrDefault();
            }
        }


        protected override List<User> GetList(Expression<Func<User, bool>> filter, ApplicationDbContext context)
        {
            return filter == null
               ? context.Users.ToList()
               : context.Users.Where(filter).ToList();
        }

        protected override User Get(User entity, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        protected override User Get(Expression<Func<User, bool>> filter, ApplicationDbContext context)
        {
            return context.Users.SingleOrDefault(filter);
        }
    }
}
