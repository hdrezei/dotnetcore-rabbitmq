using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Context
{
	public class MongoMessageContext<TEntity>
	{
		private readonly IMongoDatabase _database = null;
        private readonly string _collectionName = null;

		public MongoMessageContext(IOptions<MongoDbSettings> settings, string collectionName)
		{
            // var client = new MongoClient(settings.Value.ConnectionString);
		    var client = new MongoClient("mongodb://localhost:27017/MongoMessage");
            //_database = client.GetDatabase(settings.Value.Database);
		    _database = client.GetDatabase("MongoMessage");
            _collectionName = collectionName;
		}

		public IMongoCollection<TEntity> Collection => _database.GetCollection<TEntity>(_collectionName);
	}
}
