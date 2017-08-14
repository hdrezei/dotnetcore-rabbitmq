using MongoDB.Driver;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Logs;
using nyom.domain.Message;
using nyom.infra.Data.MongoDb.Context;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class LogsRepository : ServiceBase<Logs>
	{
		private readonly MongoMessageContext _mongoContext;
		private const string CollectionName = "Logs";

		public LogsRepository(IRepositoryBase<Logs, string> repositoryBase,
			MongoMessageContext mongoContext) : base(repositoryBase)
		{
			_mongoContext = mongoContext;
		}

		protected MongoCollection<Logs> Collection =>
			_mongoContext.MgDatabase.GetCollection<Logs>(CollectionName);
	}
}