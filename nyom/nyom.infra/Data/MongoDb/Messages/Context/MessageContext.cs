using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace nyom.infra.Data.MongoDb.Messages.Context
{
    public class MessageContext 
    {
	    public MongoDatabase MgDatabase;
	    public IConfigurationRoot Configuration { get; }
		public MessageContext(IConfigurationRoot configuration)
	    {
		    Configuration = configuration;
		    var mongoUrl = new MongoUrl(Configuration.GetConnectionString("MongoMessage"));
			var client = new MongoClient(mongoUrl);
		    var server = client.GetServer();
		    MgDatabase = server.GetDatabase(mongoUrl.DatabaseName);
		}
	}
}
