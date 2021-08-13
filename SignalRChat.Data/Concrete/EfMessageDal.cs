using Microsoft.EntityFrameworkCore;
using School.Core.DataAccess.EntityFramework;
using SignalRChat.Data.Abstract;
using SignalRChat.Data.Context;
using SignalRChat.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Concrete
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, ApplicationDbContext>, IMessageDal
    {
        public Message GetMessage(Expression<Func<Message, bool>> filter)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Messages
                        .Where(filter)
                        .Include(i => i.Sender)
                        .Include(i => i.Receiver)
                        .FirstOrDefault();

                return query;
            }
        }

        public IList<Message> GetMessageList(Expression<Func<Message, bool>> filter)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Messages.Where(filter).Include(i => i.Sender).Include(i => i.Receiver);

                return query.ToList();
            }

        }

        protected override List<Message> GetList(Expression<Func<Message, bool>> filter, ApplicationDbContext context)
        {
            return filter == null
               ? context.Messages.ToList()
               : context.Messages.Where(filter).ToList();
        }

        protected override Message Get(Message entity, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        protected override Message Get(Expression<Func<Message, bool>> filter, ApplicationDbContext context)
        {
            return context.Messages.SingleOrDefault(filter);
        }
    }
}
