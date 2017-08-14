using nyom.domain.core.MongoDb.Message.Interface;

namespace nyom.domain.MongoMessage
{
	public interface IMongoMessageRepository: IRepositoryBaseMongoMessage<Message,string>
	{
	}
}