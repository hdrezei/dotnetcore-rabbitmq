using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nyom.domain.Message;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class MessageRepository : RepositoryBase<Message>
	{
		//private readonly IMongoContext<Message> _mongoContext;

		//public MessageRepository(IRepositoryBase<Message> repositoryBase,
		//	IMongoContext<Message> mongoContext) : base(repositoryBase)
		//{
		//	_mongoContext = mongoContext;
		//}

		//protected IMongoCollection<Message> Collection(string collention)
		//{
		//	return _mongoContext.Database.GetCollection<Message>(collention);
		//}
		protected override IMongoCollection<Message> Collection { get; }

		public MessageRepository(IOptions<MongoDbSettings> settings, string collectionName) : base(settings, collectionName)
		{
		}
	}
}
