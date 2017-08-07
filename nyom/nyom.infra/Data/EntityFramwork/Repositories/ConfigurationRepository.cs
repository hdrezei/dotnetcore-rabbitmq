using nyom.domain.Configuration;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
   public class ConfigurationRepository : RepositoryBaseCrm<Configuration> , IConfigurationRepository
    {
	    public ConfigurationRepository(CrmContext context) : base(context)
	    {
	    }
    }
}
