using SignalRChat.Core.Models;
using SignalRChat.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Business.Abstract
{
    public interface IMessageService
    {
        StatusModel<IList<Message>> GetMessageList(Expression<Func<Message, bool>> filter);
        StatusModel<Message> GetMessage(Expression<Func<Message, bool>> filter);

        StatusModel<Message> Get(Expression<Func<Message, bool>> filter);

        StatusModel<IList<Message>> GetList(Expression<Func<Message, bool>> filter);

        StatusModel<Message> Add(Message entity);

        StatusModel<Message> Update(Message entity);

        StatusModel<Message> Delete(Expression<Func<Message, bool>> filter);
    }
}
