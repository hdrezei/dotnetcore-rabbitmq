using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace nyom.infra.Data.MongoDb.Context
{
    public class MongoMessageContext 
    {
	    public MongoDatabase MgDatabase;
	    public IConfigurationRoot Configuration { get; }
		public MongoMessageContext(IConfigurationRoot configuration)
	    {
		    Configuration = configuration;
		    var mongoUrl = new MongoUrl(Configuration.GetConnectionString("MongoMessage"));
			var client = new MongoClient(mongoUrl);
		    var server = client.GetServer();
		    MgDatabase = server.GetDatabase(mongoUrl.DatabaseName);
		}
	}
}
