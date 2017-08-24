using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace nyom.domain.core.MongoDb.Repository.Interface
{
	public interface IServiceBase<TEntity>
	{
		IEnumerable<TEntity> GetAll();
		TEntity GetOne(TEntity context);
		TEntity GetOne(Guid id);
		TEntity InsertOne(TEntity context);
		TEntity RemoveOne(Guid id);
		IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
	    TEntity Save(TEntity entity);

	}
}