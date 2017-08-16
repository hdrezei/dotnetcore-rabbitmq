using nyom.domain.core.MongoDb.Repository.Models;

namespace nyom.domain.Results
{
	public class ResultsServices :ServiceBase<Results> , IResultsServices
	{
		private readonly IResultsRepository _resultsRepository;

		public ResultsServices(IResultsRepository resultsRepository) : base(resultsRepository)
		{
			_resultsRepository = resultsRepository;
		}
	}
}