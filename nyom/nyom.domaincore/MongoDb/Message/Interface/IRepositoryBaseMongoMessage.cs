using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nyom.domain.core.MongoDb.Message.Interface
{
	public interface IRepositoryBaseMongoMessage<TEntity>  where TEntity : class
	{
		TEntity Get(Guid id);
		TEntity Find(Expression<Func<TEntity, bool>> predicate);
		ICollection<TEntity> All();
		ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
		TEntity Save(TEntity entity);
		bool Delete(Guid id);
		bool Delete(TEntity entity);
		TEntity Update(TEntity entity);
	}
}
