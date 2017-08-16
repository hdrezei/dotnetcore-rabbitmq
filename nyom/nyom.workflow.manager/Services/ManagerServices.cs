using System;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.manager.Services
{
	public class ManagerServices : IManagerServices
	{
	    private static ICampanhaWorkflowRepository _campanhaWorkflowRepository;
		private static IManagerFactory _managerFactory;

	    public ManagerServices(ICampanhaWorkflowRepository campanhaWorkflowRepository, IManagerFactory managerFactory)
	    {
		    _campanhaWorkflowRepository = campanhaWorkflowRepository;
		    _managerFactory = managerFactory;

	    }

		public void Start(string Id)
		{
			var dadosCampanha = _campanhaWorkflowRepository.Find(a => a.CampanhaId.Equals(Id));

			_managerFactory.VerificarStatusCampanha(dadosCampanha.CampanhaId.ToString());
		}



		public void AtualizarStatusCampanha(Guid id, WorkflowStatus status)
	    {
		    var dadosCampanha = _campanhaWorkflowRepository.Get(id);
		    dadosCampanha.Status = status;
		    _campanhaWorkflowRepository.Save(dadosCampanha);
	    }

		
	}
}
