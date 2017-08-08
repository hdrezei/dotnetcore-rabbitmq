using nyom.domaincore.Models;

namespace nyom.domain.Workflow.Workflow
{
	public class WorkflowService : ServiceBaseWorkflow<Workflow>, IWorkflowService
	{
		private readonly IWorkflowRepository _workflowRepository;
		public WorkflowService(IWorkflowRepository workflowRepository) : base(workflowRepository)
		{
			_workflowRepository = workflowRepository;
		}
	}
}