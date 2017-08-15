namespace nyom.domain.core.MongoDb.IEntity
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}

	public interface IEntity : IEntity<string>
	{
	}
}