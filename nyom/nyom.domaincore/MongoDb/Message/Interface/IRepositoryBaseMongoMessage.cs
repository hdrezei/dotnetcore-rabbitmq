using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nyom.domain.core.MongoDb.Message.Interface
{
	public interface IRepositoryBaseMongoMessage<TEntity, in TKey>  where TEntity : IEntity<TKey>
	{
		TEntity Get(Guid id);
		object Find(Expression<Func<TEntity, bool>> predicate);
		ICollection<TEntity> All();
		ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
		void Save(TEntity entity);
		void Delete(Guid id);
		bool Delete(TEntity entity);
		TEntity Update(TEntity entity);
	}
}
