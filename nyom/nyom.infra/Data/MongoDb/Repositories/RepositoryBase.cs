using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.infra.Data.MongoDb.Context;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
		where TEntity : IEntity
	{
		protected readonly MongoMessageContext<TEntity> Context;
		protected string CollectionName => "4063DEBE-6EA0-4C54-B36E-2C65D0D6D060"; // Environment.GetEnvironmentVariable("CAMPANHA");

		protected RepositoryBase(IOptions<MongoDbSettings> settings)
		{
			Context = new MongoMessageContext<TEntity>(settings, CollectionName);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Collection
				.AsQueryable()
				.Where(predicate.Compile())
				.ToList();
		}

		public TEntity GetOne(TEntity context)
		{
			return Context.Collection.Find(new BsonDocument("_id", context.Id)).FirstOrDefault();
		}

		public TEntity GetOne(Guid id)
		{
			return Context.Collection.Find(f => f.Id.Equals(id)).FirstOrDefault();
		}

		public TEntity InsertOne(TEntity entity)
		{
			Context.Collection.InsertOne(entity);
			return entity;
		}

		public TEntity RemoveOne(Guid id)
		{
			return Context.Collection.FindOneAndDelete(f => f.Id.Equals(id));
		}
	}
}