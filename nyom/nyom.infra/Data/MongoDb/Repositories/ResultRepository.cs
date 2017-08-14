using MongoDB.Driver;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Message;
using nyom.domain.Results;
using nyom.infra.Data.MongoDb.Context;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class ResultsRepository : ServiceBase<Results>
	{
		private readonly MongoMessageContext _mongoContext;
		private const string CollectionName = "Results";

		public ResultsRepository(IRepositoryBase<Results, string> repositoryBase,
			MongoMessageContext mongoContext) : base(repositoryBase)
		{
			_mongoContext = mongoContext;
		}

		protected MongoCollection<Results> Collection =>
			_mongoContext.MgDatabase.GetCollection<Results>(CollectionName);
	}
}