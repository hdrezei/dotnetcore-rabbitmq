using nyom.domain.Workflow.Campanha;

namespace nyom.infra.Data.EntityFramwork.Repositories.Workflow
{
	public class CampanhaWorkflowRepository :RepositoryBase<CampanhaWorkflow>, ICampanhaWorkflowRepository
	{
		public CampanhaWorkflowRepository(IDbContext context) : base(context)
		{
		}
	}
}