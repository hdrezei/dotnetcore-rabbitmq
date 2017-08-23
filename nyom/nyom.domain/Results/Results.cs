using nyom.domain.core.MongoDb.Repository.Interface;
using System;

namespace nyom.domain.Results
{
	public class Results : IEntity
    {
	    public Guid Id { get; set; }
		public string Mensagem { get; set; }
    }
}
