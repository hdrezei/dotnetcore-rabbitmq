using nyom.domain.core.MongoDb.Message.Models;

namespace nyom.domain.MongoMessage
{
	public class MessageServices : ServiceBaseMongoMessage<Message>, IMongoMessageService
	{
		private readonly IMongoMessageRepository _messageRepository;
		public MessageServices(IMongoMessageRepository messageRepository) : base(messageRepository)
		{
			_messageRepository = messageRepository;
		}
	}
}