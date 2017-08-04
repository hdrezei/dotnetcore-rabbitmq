using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class WorkflowRepository : RepositoryBaseWorkflow<Workflow>
	{
		public WorkflowRepository(WorkflowContext context) : base(context)
		{
		}
	}
}