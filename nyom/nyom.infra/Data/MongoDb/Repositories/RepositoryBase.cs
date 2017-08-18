using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.infra.Data.MongoDb.Context;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public  class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
		where TEntity : IEntity<string>
	{
		protected readonly MongoMessageContext<TEntity> _context;
		protected string CollectionName => Environment.GetEnvironmentVariable("CAMPANHA");

		protected RepositoryBase(IOptions<MongoDbSettings> settings)
		{
			_context = new MongoMessageContext<TEntity>(settings, CollectionName);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Collection
				.AsQueryable()
				.Where(predicate.Compile())
				.ToList();
		}


		public async Task<TEntity> GetOneAsync(TEntity context)
		{
			return await _context.Collection.Find(new BsonDocument("_id", context.Id)).FirstOrDefaultAsync();
		}

		public async Task<TEntity> GetOneAsync(string id)
		{
			return await _context.Collection.Find(f => f.Id.Equals(id)).FirstOrDefaultAsync();
		}

		public async Task<TEntity> SaveOneAsync(TEntity Context)
		{
			await _context.Collection.InsertOneAsync(Context);
			return Context;
		}

		public async Task<TEntity> RemoveOneAsync(TEntity context)
		{
			return await _context.Collection.FindOneAndDeleteAsync(context.Id);
		}

		public async Task<TEntity> RemoveOneAsync(string id)
		{
			return await _context.Collection.FindOneAndDeleteAsync(id);
		}
	}
}