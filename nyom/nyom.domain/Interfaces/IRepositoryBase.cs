using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nyom.domain.Interfaces
{
	public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
	{
		void Add(TEntity obj);
		TEntity GetById(Guid id);
		IEnumerable<TEntity> GetAll();
		void Update(TEntity obj);
		void Remove(Guid id);
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		int SaveChanges();
	}
}