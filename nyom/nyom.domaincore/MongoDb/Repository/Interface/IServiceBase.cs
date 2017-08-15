using nyom.domain.core.MongoDb.IEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace nyom.domain.core.MongoDb.Repository.Interface
{
	public interface IServiceBase<TEntity>
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetOneAsync(TEntity context);
		Task<TEntity> GetOneAsync(string id);
		Task<TEntity> SaveOneAsync(TEntity Context);
		Task<TEntity> RemoveOneAsync(TEntity context);
		Task<TEntity> RemoveOneAsync(string id);
		IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
	}
}