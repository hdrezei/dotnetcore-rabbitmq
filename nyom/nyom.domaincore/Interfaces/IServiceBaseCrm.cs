using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nyom.domaincore.Interfaces
{
	public interface IServiceBaseCrm<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(Guid id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Save(TEntity entity);
        bool Delete(Guid id);
        bool Delete(TEntity entity);
    }
}