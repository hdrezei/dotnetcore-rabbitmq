using nyom.domain.Workflow.Campanha;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.manager.Services
{
	public class ManagerServices 
	{
	    private static ICampanhaWorkflowRepository _campanhaWorkflowRepository;
		private static IManagerFactory _managerFactory;

	    public ManagerServices(ICampanhaWorkflowRepository campanhaWorkflowRepository, IManagerFactory managerFactory)
	    {
		    _campanhaWorkflowRepository = campanhaWorkflowRepository;
		    _managerFactory = managerFactory;

	    }

		public void Start(string id)
		{
			_managerFactory.VerificarStatusCampanha(id);
		}
	}
}
