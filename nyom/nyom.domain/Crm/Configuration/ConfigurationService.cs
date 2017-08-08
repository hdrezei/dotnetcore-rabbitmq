namespace nyom.domain.Crm.Configuration
{
	public class ConfigurationService : ServiceBaseCrm<Crm.Configuration.Configuration>, IConfigurationService
	{
		private readonly IConfigurationRepository _configurationRepository;

		public ConfigurationService(IConfigurationRepository configurationRepository) : base(configurationRepository)
		{
			_configurationRepository = configurationRepository;
		}
	}
}