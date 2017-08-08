using nyom.domaincore.Models;

namespace nyom.domain.Workflow.Campanha
{
	public class CampanhaWorkflowService : ServiceBaseWorkflow<domain.Workflow.Campanha.CampanhaWorkflow> , ICampanhaWorkflowService
	{
		private readonly ICampanhaWorkflowRepository _campanhaRepository;
		public CampanhaWorkflowService(ICampanhaWorkflowRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
	}
}