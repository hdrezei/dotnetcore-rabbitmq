using nyom.domain.core.MongoDb.IEntity;


namespace nyom.domain.Logs
{
   public class Logs : IEntity
   {
	    public string Id { get; set; }
		public string LogMessage { get; set; }
		public string Level { get; set; }
    }
}
