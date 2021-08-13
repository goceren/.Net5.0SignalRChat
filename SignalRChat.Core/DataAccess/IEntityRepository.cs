using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SignalRChat.Core.DataAccess
{
    public interface IEntityRepository<T> : IDisposable
    {
        T Add(T entity);
        T Update(T entity);
        bool UpdateAll(IList<T> entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> filter = null);
        T Get(T entity);
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetEntities(Expression<Func<T, bool>> filter = null);
    }

}
