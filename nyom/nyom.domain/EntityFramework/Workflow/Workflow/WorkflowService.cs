using nyom.domain.core.EntityFramework.Models;

namespace nyom.domain.EntityFramework.Workflow.Workflow
{
	public class WorkflowService : ServiceBase<domain.Workflow.Workflow.Workflow>, IWorkflowService
	{
		private readonly IWorkflowRepository _workflowRepository;
		public WorkflowService(IWorkflowRepository workflowRepository) : base(workflowRepository)
		{
			_workflowRepository = workflowRepository;
		}
	}
}