using MongoDB.Driver;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Message;
using nyom.infra.Data.MongoDb.Context;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class MessageRepository : ServiceBase<Message>
	{
		private readonly MongoContext _mongoContext;
		private const string CollectionName = "Message";

		public MessageRepository(IRepositoryBase<Message, string> repositoryBase,
			MongoContext mongoContext) : base(repositoryBase)
		{
			_mongoContext = mongoContext;
		}

		protected MongoCollection<Message> Collection =>
			_mongoContext.MgDatabase.GetCollection<Message>(CollectionName);
	}
}