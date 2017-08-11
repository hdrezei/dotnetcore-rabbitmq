using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using nyom.domain.core.MongoDb.Message.Interface;

namespace nyom.domain.core.MongoDb.Message.Models
{
	public class ServiceBaseMongoMessage<TEntity> : IServiceBaseMongoMessage<TEntity,string> where TEntity : IEntity
	{
		private readonly IReposittoryBaseMongoMessage<TEntity,string> _reposittoryBaseMongoMessage;

		public ServiceBaseMongoMessage(IReposittoryBaseMongoMessage<TEntity,string> reposittoryBaseMongoMessage)
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