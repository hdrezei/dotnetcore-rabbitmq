using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.Message.Interface;
using nyom.infra.Data.MongoDb.Messages.Context;

namespace nyom.infra.Data.MongoDb.Messages.Repositories
{
	public class RepositoryBaseMongoMessasge<TEntity> : IRepositoryBaseMongoMessage<TEntity> where TEntity : class
	{

		private readonly IMongoDatabase _db;
		private IMongoCollection<TEntity> _colecao;

		public RepositoryBaseMongoMessasge()
		{
			_db = new MesssageContext();
			_colecao = _db.GetCollection<TEntity>(typeof(TEntity).Name);
		}
		

		public TEntity Get(Guid id)
		{
			return _colecao.Find(p => p.Id == id).SingleOrDefault();
		}

		public TEntity Find(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public ICollection<TEntity> All()
		{
			return _colecao.Find(new BsonDocument()).ToList();
		}

		public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _colecao.Find(predicate).ToList();
		}

		public TEntity Save(TEntity entity)
		{
		 _colecao.InsertOne(entity);
		}

		public bool Delete(Guid id)
		{
			_colecao.DeleteOne(e => e.Id == id);
		}

		public bool Delete(TEntity entity)
		{
			_colecao.DeleteOneAsync(entity);
		}

		public TEntity Update(TEntity entity)
		{
			_colecao.ReplaceOne(e => e.Id == entity.Id, entity);
		}
	}
}
