using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.Message.Interface;

namespace nyom.infra.Data.MongoDb.Messages.Repositories
{
	public abstract class RepositoryBaseMongoMessasge<TEntity> : IRepositoryBaseMongoMessage<TEntity, string>
		where TEntity : IEntity
	{
		protected abstract IMongoCollection<TEntity> Collection { get; }


		public TEntity Get(Guid id)
		{
			return Collection.Find(x => x.Id.Equals(id)).FirstOrDefault();
		}

		public object Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Collection.Find(predicate).ToListAsync();
		}

		public ICollection<TEntity> All()
		{
			return Collection.Find(new BsonDocument()).ToList();
		}

		public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return Collection.Find(predicate).ToList();
		}

		public void Save(TEntity entity)
		{
			Collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
			{
				IsUpsert = true
			});
		}

		public void Delete(Guid id)
		{
			Collection.DeleteOne(a => a.Id.Equals(id));
		}

		public void Delete(TEntity entity)
		{
			Collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
		}

		public TEntity Update(TEntity entity)
		{
			Collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
			{
				IsUpsert = true
			});

			return entity;
		}
	}
}
