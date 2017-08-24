using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace nyom.domain.core.MongoDb.Repository.Interface
{
	public interface IRepositoryBase<TEntity> : IDisposable
	{
		TEntity GetOne(TEntity entity);
		TEntity GetOne(Guid id);
		TEntity InsertOne(TEntity entity);
		TEntity RemoveOne(Guid id);
		IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
	    TEntity Save(TEntity entity);

	}
}