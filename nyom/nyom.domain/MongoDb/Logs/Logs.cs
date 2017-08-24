using nyom.domain.core.MongoDb.Repository.Interface;
using System;

namespace nyom.domain.Logs
{
   public class Logs : IEntity
   {
	    public Guid Id { get; set; }
		public string LogMessage { get; set; }
		public string Level { get; set; }
    }
}
