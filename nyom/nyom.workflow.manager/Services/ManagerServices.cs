using nyom.domain.Workflow.Campanha;
using nyom.infra.Factory;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.manager.Services
{
	public class ManagerServices 
	{
	    private static IManagerFactory _managerFactory;

	    public ManagerServices( IManagerFactory managerFactory)
	    {
	        _managerFactory = managerFactory;
	    }

		public void Start(string id)
		{
			_managerFactory.VerificarStatusCampanha(id);
		}
	}
}
