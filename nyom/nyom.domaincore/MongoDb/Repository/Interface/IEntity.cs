namespace nyom.domain.core.MongoDb.Repository.Interface
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}


}