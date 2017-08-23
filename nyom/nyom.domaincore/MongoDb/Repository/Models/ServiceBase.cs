using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

		public IEnumerable<TEntity> GetAll()
		{
			throw new NotImplementedException();
		}

		public TEntity GetOne(TEntity context)
		{
			return _repositoryBase.GetOne(context);
		}

		public TEntity GetOne(Guid id)
		{
			return _repositoryBase.GetOne(id);
		}

		public TEntity InsertOne(TEntity context)
		{
			return _repositoryBase.InsertOne(context);
		}

		public TEntity RemoveOne(Guid id)
		{
			return _repositoryBase.RemoveOne(id);
		}

		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _repositoryBase.FindAll(predicate);
		}
	}
}