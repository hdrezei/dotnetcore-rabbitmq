using nyom.domain.Nyom.Configuration;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
   public class ConfigurationRepository : RepositoryBase<Configuration> , IConfigurationRepository
    {
	    public ConfigurationRepository(NyomContext context) : base(context)
	    {
	    }
    }
}
