using Microsoft.Extensions.Options;
using nyom.domain.Results;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public class ResultsRepository : RepositoryBase<Results>, IResultsRepository
	{
		public ResultsRepository(IOptions<MongoDbSettings> settings) : base(settings)
		{
		}
	}
}