using nyom.domain.core.MongoDb.Message.Interface;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.Message
{
	public interface IMessageRepository: IRepositoryBase<Message,string>
	{
	}
}