using System;

namespace nyom.domain.core.MongoDb.Repository.Interface
{
	public interface IEntity
	{
		Guid Id { get; set; }
	}
}