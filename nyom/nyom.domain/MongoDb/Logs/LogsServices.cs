using nyom.domain.core.MongoDb.Repository.Models;

namespace nyom.domain.MongoDb.Logs
{
    class LogsServices : ServiceBase<Logs>,ILogsService
    {
	    private readonly ILogsRepository _logsRepository;

	    public LogsServices(ILogsRepository logsRepository) :base(logsRepository)
	    {
		    _logsRepository = logsRepository;
	    }
    }
}
