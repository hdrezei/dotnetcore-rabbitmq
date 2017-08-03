using nyom.domain.core.Models;
using nyom.domain.Configuration;

namespace nyom.domain.Notifications
{
	public class ConfigurationService : ServiceBase<Configuration.Configuration>, IConfigurationService
	{
		private readonly IConfigurationRepository _configurationRepository;

		public ConfigurationService(IConfigurationRepository configurationRepository) : base(configurationRepository)
		{
			_configurationRepository = configurationRepository;
		}
	}
}