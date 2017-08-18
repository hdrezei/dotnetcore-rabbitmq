using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.Results
{
	public class Results : IEntity<string>
    {
	    public string Id { get; set; }
    }
}
