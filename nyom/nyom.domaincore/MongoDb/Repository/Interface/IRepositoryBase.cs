using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace nyom.domain.core.MongoDb.Repository.Interface
{
	public interface IRepositoryBase<TEntity> : IDisposable
	{
		Task<TEntity> GetOneAsync(TEntity context);
		Task<TEntity> GetOneAsync(Guid id);
		Task<TEntity> SaveOneAsync(TEntity Context);
		Task<TEntity> RemoveOneAsync(Guid id);
		IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
	    TEntity Save(TEntity entity);

	}
}