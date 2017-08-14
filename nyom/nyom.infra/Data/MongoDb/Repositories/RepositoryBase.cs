using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.Message.Interface;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity, string>
		where TEntity : IEntity
	{
		protected abstract IMongoCollection<TEntity> Collection { get; }

		public TEntity Get(Guid id)
		{
			return Collection.Find(a => a.Id.Equals(id)).FirstOrDefault();
		}

		public TEntity Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Collection.Find(predicate).FirstOrDefault();
		}

		public ICollection<TEntity> All()
		{
			return Collection.Find(new BsonDocument()).ToList();
		}

		public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return Collection.Find(predicate).ToList();
		}

		public TEntity Save(TEntity entity)
		{
			Collection.ReplaceOneAsync(
				x => x.Id.Equals(entity.Id),
				entity,
				new UpdateOptions
				{
					IsUpsert = true
				});

			return entity;
		}

		public void Delete(Guid id)
		{
			Collection.DeleteOne(x => x.Id.Equals(id));
		}

		public void Delete(TEntity entity)
		{
			Collection.DeleteOne(a => a.Id.Equals(entity.Id));
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