using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.Logs
{
   public class Logs : IEntity<string>
   {
	    public string Id { get; set; }
		public string LogMessage { get; set; }
		public string Level { get; set; }
    }
}
