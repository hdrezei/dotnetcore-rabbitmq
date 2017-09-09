using System;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.MongoDb.Logs
{
   public class Logs : IEntity
   {
	    public Guid Id { get; set; }
		public string LogMessage { get; set; }
		public string Level { get; set; }
    }
}
