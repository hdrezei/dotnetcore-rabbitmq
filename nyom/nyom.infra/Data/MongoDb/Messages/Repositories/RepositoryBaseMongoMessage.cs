using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.Message.Interface;
using nyom.infra.Data.MongoDb.Messages.Context;
using IAsyncCursorSourceExtensions = MongoDB.Driver.IAsyncCursorSourceExtensions;
using IFindFluentExtensions = MongoDB.Driver.IFindFluentExtensions;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;
using IMongoDatabase = MongoDB.Driver.IMongoDatabase;

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
			return  Collection.Find(predicate).ToListAsync();
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
			 Collection.InsertOne(entity);
		}

		public void Delete(Guid id)
		{
			Collection.DeleteOne(a => a.Id.Equals(id));
		}

		public bool Delete(TEntity entity)
		{
			return 
		}

		public TEntity Update(TEntity entity)
		{
			return Collection.UpdateOne(entity);
		}
	}


	//public class RepositoryBaseMongoMessasge<TEntity> : IRepositoryBaseMongoMessage<TEntity> where TEntity : class
	//{
	//	private readonly IMongoDatabase _db;
	//	private readonly IMongoCollection<TEntity> _colecao;

	//	public RepositoryBaseMongoMessasge()
	//	{
	//		_db = new MesssageContext();
	//		_colecao = _db.GetCollection<TEntity>(typeof(TEntity).Name);
	//	}


	//	public TEntity Get(Guid id)
	//	{
	//		return IFindFluentExtensions.SingleOrDefault(IMongoCollectionExtensions.Find(_colecao, p => p.Id == id));
	//	}

	//	public object Find(Expression<Func<TEntity, bool>> predicate)
	//	{
	//		return _colecao.Find(predicate).ToList();
	//	}

	//	public ICollection<TEntity> All()
	//	{
	//		return IAsyncCursorSourceExtensions.ToList(IMongoCollectionExtensions.Find(_colecao, new BsonDocument()));
	//	}

	//	public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
	//	{
	//		return IAsyncCursorSourceExtensions.ToList(IMongoCollectionExtensions.Find(_colecao, predicate));
	//	}

	//	public void Save(TEntity entity)
	//	{
	//		_colecao.InsertOne(entity);
	//	}



	//	public bool Delete(TEntity entity)
	//	{
	//		Debug.Assert(entity != null, "entity != null");
	//		return _colecao.DeleteOneAsync(entity);
	//	}

	//	public TEntity Update(TEntity entity)
	//	{
	//		return _colecao.ReplaceOne(e => e.Id == entity.Id, entity);
	//	}
	//}
}
