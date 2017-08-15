using MongoDB.Driver;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Results;
using nyom.infra.Data.MongoDb.Context;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class ResultsRepository : ServiceBase<Results>
	{
		private readonly MongoMessageContext<Results> _mongoContext;
		

		public ResultsRepository(IRepositoryBase<Results> repositoryBase,
			MongoMessageContext<Results> mongoContext) : base(repositoryBase)
		{
			_mongoContext = mongoContext;
		}

		protected MongoCollection<Results> Collection(string collection)
		{
			return _mongoContext.MgDatabase.GetCollection<Results>(collection);
		}
	}
}