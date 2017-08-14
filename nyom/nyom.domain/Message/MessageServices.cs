using nyom.domain.core.MongoDb.Repository.Models;

namespace nyom.domain.Message
{
	public class MessageServices : ServiceBase<Message>, IMessageService
	{
		private readonly IMessageRepository _messageRepository;
		public MessageServices(IMessageRepository messageRepository) : base(messageRepository)
		{
			_messageRepository = messageRepository;
		}
	}
}