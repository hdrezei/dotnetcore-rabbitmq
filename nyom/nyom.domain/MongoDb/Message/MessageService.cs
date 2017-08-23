using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Message;

namespace nyom.domain.MongoDb.Message
{
	public class MessageService : ServiceBase<domain.Message.Message>, IMessageService
	{
		private readonly IMessageRepository _messageRepository;
		public MessageService(IMessageRepository messageRepository) : base(messageRepository)
		{
			_messageRepository = messageRepository;
		}
	}
}