using MongoDB.Driver;
using nyom.domain.core.MongoDb.Message.Interface;
using nyom.domain.core.MongoDb.Message.Models;
using nyom.domain.MongoMessage;
using nyom.infra.Data.MongoDb.Messages.Context;

namespace nyom.infra.Data.MongoDb.Messages.Repositories
{
	public class MongoMessageRepository : ServiceBaseMongoMessage<Message>
	{
		private readonly MessageContext _messageContext;
		private const string MessageCollectionName = "Message";

		public MongoMessageRepository(IRepositoryBaseMongoMessage<Message, string> reposittoryBaseMongoMessage,
			MessageContext messageContext) : base(reposittoryBaseMongoMessage)
		{
			_messageContext = messageContext;
		}

		protected MongoCollection<Message> Collection =>
			_messageContext.MgDatabase.GetCollection<Message>(MessageCollectionName);
	}
}