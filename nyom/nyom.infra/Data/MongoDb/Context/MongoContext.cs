using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace nyom.infra.Data.MongoDb.Context
{
    public class MongoContext 
    {
	    public MongoDatabase MgDatabase;
	    public IConfigurationRoot Configuration { get; }
		public MongoContext(IConfigurationRoot configuration)
	    {
		    Configuration = configuration;
		    var mongoUrl = new MongoUrl(Configuration.GetConnectionString("MongoContext"));
			var client = new MongoClient(mongoUrl);
		    var server = client.GetServer();
		    MgDatabase = server.GetDatabase(mongoUrl.DatabaseName);
		}
	}
}
