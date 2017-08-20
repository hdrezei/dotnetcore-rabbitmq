using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories.Workflow
{
	public class WorkflowRepository : RepositoryBase<domain.Workflow.Workflow.Workflow>, IWorkflowRepository
	{
		public WorkflowRepository(IDbContext context) : base(context)
		{
		}
	}
}