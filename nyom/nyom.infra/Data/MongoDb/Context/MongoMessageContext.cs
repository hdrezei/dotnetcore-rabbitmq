using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Context
{
 //   public class MongoMessageContext 
 //   {
	//    public MongoDatabase MgDatabase;
	//    public IConfigurationRoot Configuration { get; }
	//	public MongoMessageContext(IConfigurationRoot configuration)
	//    {
	//	    Configuration = configuration;
	//	    var mongoUrl = new MongoUrl(Configuration.GetConnectionString("MongoMessage"));
	//		var client = new MongoClient(mongoUrl);
	//	    var server = client.GetServer();
	//	    MgDatabase = server.GetDatabase(mongoUrl.DatabaseName);
	//	}
	//}


	public class MongoMessageContext<TEntity> 
	{
		private IMongoDatabase _database = null;
		
		private readonly string _collectionName =null;

		public MongoMessageContext (IOptions<MongoDbSettings> settings, string collectionName)
		{
			
			var client = new MongoClient(settings.Value.ConnectionString);
			if (client != null)
			{
				_database = client.GetDatabase(settings.Value.Database);
			}

			_collectionName = collectionName;
		}

		public IMongoCollection<TEntity> Collection => _database.GetCollection<TEntity>(_collectionName);
	}

}
