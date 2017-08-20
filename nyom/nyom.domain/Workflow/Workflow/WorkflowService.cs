using nyom.domain.core.EntityFramework.Models;

namespace nyom.domain.Workflow.Workflow
{
	public class WorkflowService : ServiceBase<Workflow>, IWorkflowService
	{
		private readonly IWorkflowRepository _workflowRepository;
		public WorkflowService(IWorkflowRepository workflowRepository) : base(workflowRepository)
		{
			_workflowRepository = workflowRepository;
		}
	}
}