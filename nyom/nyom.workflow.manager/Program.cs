using System;
using nyom.domain.Workflow.Campanha;

namespace nyom.workflow.manager
{
	public class Program
	{
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IManagerFactory _managerFactory;


		public Program(ICampanhaWorkflowService campanhaWorkflowService, IManagerFactory managerFactory)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
			_managerFactory = managerFactory;
		}

		public void VerificarStatusCampanha(Guid id)
		{
			var dadosCampanha = _campanhaWorkflowService.Get(id);

			_managerFactory.VerificarStatusCampanha(dadosCampanha.CampanhaId, dadosCampanha.Status);
		}
	}
}
