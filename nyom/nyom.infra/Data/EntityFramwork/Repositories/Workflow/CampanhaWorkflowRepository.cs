using nyom.domain.Workflow.Campanha;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class CampanhaWorkflowRepository :RepositoryBaseWorkflow<CampanhaWorkflow>, ICampanhaWorkflowRepository
	{
		public CampanhaWorkflowRepository(WorkflowContext context) : base(context)
		{
		}
	}
}