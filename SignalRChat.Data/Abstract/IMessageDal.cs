using SignalRChat.Core.DataAccess;
using SignalRChat.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        IList<Message> GetMessageList(Expression<Func<Message, bool>> filter);

        Message GetMessage(Expression<Func<Message, bool>> filter);
    }
}
