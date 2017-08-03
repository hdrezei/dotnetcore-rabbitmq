using nyom.domain.core.Models;

namespace nyom.domain.Configuration
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