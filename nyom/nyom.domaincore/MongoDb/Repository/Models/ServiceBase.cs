using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.core.MongoDb.Repository.Models
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity>
	{
		private readonly IRepositoryBase<TEntity> _repositoryBase;

		public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
		{
			_repositoryBase = repositoryBase;
		}

		public Task<IEnumerable<TEntity>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<TEntity> GetOneAsync(TEntity context)
		{
			return _repositoryBase.GetOneAsync(context);
		}

		public Task<TEntity> GetOneAsync(Guid id)
		{
			return _repositoryBase.GetOneAsync(id);
		}

		public Task<TEntity> SaveOneAsync(TEntity context)
		{
			return _repositoryBase.SaveOneAsync(context);
		}

		public Task<TEntity> RemoveOneAsync(Guid id)
		{
			return _repositoryBase.RemoveOneAsync(id);
		}

		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _repositoryBase.FindAll(predicate);
		}
	}
}