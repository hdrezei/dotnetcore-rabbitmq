namespace nyom.domain.core.MongoDb.Message.Interface
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}

	public interface IEntity : IEntity<string>
	{
	}
}