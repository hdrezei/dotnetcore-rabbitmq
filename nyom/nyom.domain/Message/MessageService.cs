using nyom.domain.core.MongoDb.Repository.Models;

namespace nyom.domain.Message
{
	public class MessageService : ServiceBase<Message>, IMessageService
	{
		private readonly IMessageRepository _messageRepository;
		public MessageService(IMessageRepository messageRepository) : base(messageRepository)
		{
			_messageRepository = messageRepository;
		}
	}
}