using nyom.domain.core.Models;

namespace nyom.domain.Crm.Configuration
{
	public class ConfigurationService : ServiceBase<Crm.Configuration.Configuration>, IConfigurationService
	{
		private readonly IConfigurationRepository _configurationRepository;

		public ConfigurationService(IConfigurationRepository configurationRepository) : base(configurationRepository)
		{
			_configurationRepository = configurationRepository;
		}
	}
}