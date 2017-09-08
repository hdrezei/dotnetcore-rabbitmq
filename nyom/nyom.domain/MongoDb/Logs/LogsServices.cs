using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.MongoDb.Logs;

namespace nyom.domain.Logs
{
    class LogsServices : ServiceBase<MongoDb.Logs.Logs>,ILogsService
    {
	    private readonly ILogsRepository _logsRepository;

	    public LogsServices(ILogsRepository logsRepository) :base(logsRepository)
	    {
		    _logsRepository = logsRepository;
	    }
    }
}
