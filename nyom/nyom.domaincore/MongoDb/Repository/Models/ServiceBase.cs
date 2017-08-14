using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using nyom.domain.core.MongoDb.Message.Interface;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.core.MongoDb.Repository.Models
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity, string> where TEntity : IEntity
	{
		private readonly IRepositoryBase<TEntity, string> _reposittoryBaseMongoMessage;

		public ServiceBase(IRepositoryBase<TEntity, string> reposittoryBaseMongoMessage)
		{
			_reposittoryBaseMongoMessage = reposittoryBaseMongoMessage;
		}

		public TEntity Get(Guid id)
		{
			return _reposittoryBaseMongoMessage.Get(id);
		}

		public TEntity Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _reposittoryBaseMongoMessage.Find(predicate);
		}

		public IEnumerable<TEntity> All()
		{
			return _reposittoryBaseMongoMessage.All();
		}

		public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _reposittoryBaseMongoMessage.FindAll(predicate);
		}

		public TEntity Save(TEntity entity)
		{
			return _reposittoryBaseMongoMessage.Save(entity);
		}

		public void Delete(Guid id)
		{
			_reposittoryBaseMongoMessage.Delete(id);
		}

		public void Delete(TEntity entity)
		{
			_reposittoryBaseMongoMessage.Delete(entity);
		}

		public TEntity Update(TEntity entity)
		{
			return _reposittoryBaseMongoMessage.Update(entity);
		}
	}
}