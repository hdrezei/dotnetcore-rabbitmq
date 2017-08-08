using nyom.domain.Crm.Campanha;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class CampanhaRepository :RepositoryBaseWorkflow<CampanhaCrm>, ICampanhaCrmRepository
	{
		public CampanhaRepository(WorkflowContext context) : base(context)
		{
		}
	}
}