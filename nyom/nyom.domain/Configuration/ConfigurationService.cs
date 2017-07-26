using nyom.domain.core.Models;
using nyom.domain.Entities;

namespace nyom.domain.Notifications
{
	public class ConfigurationService : ServiceBase<Configuration>, IConfigurationService
	{
		private readonly IConfigurationRepository _configurationRepository;

		public ConfigurationService(IConfigurationRepository configurationRepository) : base(configurationRepository)
		{
			_configurationRepository = configurationRepository;
		}
	}
}