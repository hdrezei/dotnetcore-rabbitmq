using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

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


	public class MongoMessageContext<T> : IMongoContext<T>
	{
		public IMongoDatabase Database { get; }
		public IMongoCollection<T> Collection { get; }
		public IConfigurationRoot Configuration { get; }
		public MongoDatabase MgDatabase;
		public MongoMessageContext(IConfigurationRoot configuration, string collectionName)
		{
			Configuration = configuration;
			var mongoUrl = new MongoUrl(Configuration.GetConnectionString("MongoMessage"));
			var client = new MongoClient(mongoUrl);
			var server = client.GetServer();
			MgDatabase = server.GetDatabase(mongoUrl.DatabaseName);
			Collection = Database.GetCollection<T>(collectionName);
		}
	}

}
