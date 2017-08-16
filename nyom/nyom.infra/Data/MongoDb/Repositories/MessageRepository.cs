using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using nyom.domain.Message;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Repositories
{
    public class MessageRepository : RepositoryBase<Message>,IMessageRepository
    {
	    public MessageRepository(IOptions<MongoDbSettings> settings, string collectionName) : base(settings, collectionName)
	    {
	    }
    }
}
