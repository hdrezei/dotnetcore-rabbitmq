using MongoDB.Driver;

namespace nyom.infra.Data.MongoDb.Context
{
	public interface IMongoContext<T>
	{
		IMongoDatabase Database { get; }
		IMongoCollection<T> Collection { get; }
	}
}