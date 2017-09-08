using nyom.domain.EntityFramework.Workflow.Campanha;
using nyom.domain.Workflow.Campanha;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories.Workflow
{
	public class CampanhaWorkflowRepository :RepositoryBase<CampanhaWorkflow>, ICampanhaWorkflowRepository
	{
		public CampanhaWorkflowRepository(IDbContext context) : base(context)
		{
		}
	}
}