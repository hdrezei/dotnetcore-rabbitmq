using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;

namespace nyom.domain.Workflow
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