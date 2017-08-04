using nyom.domain.core.Models;

namespace nyom.domain.Workflow.Workflow
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