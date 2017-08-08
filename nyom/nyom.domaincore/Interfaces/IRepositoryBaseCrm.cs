using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nyom.domaincore.Interfaces
{
	public interface IRepositoryBaseCrm<TEntity> : IDisposable where TEntity : class
	{
		TEntity Get(Guid id);
		TEntity Find(Expression<Func<TEntity, bool>> predicate);
		ICollection<TEntity> All();
		ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
		TEntity Save(TEntity entity);
		bool Delete(Guid id);
		bool Delete(TEntity entity);
	}
}