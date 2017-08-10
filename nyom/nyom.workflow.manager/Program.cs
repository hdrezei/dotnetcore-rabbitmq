using System;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Workflow.Campanha;

namespace nyom.workflow.manager
{
	public class Program
	{
		private readonly IPessoaService _pessoaService;
		private readonly ICampanhaCrmService _campanhaCrmService;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly ITemplateService _templateService;

		public Program(IPessoaService pessoaService, ICampanhaCrmService campanhaCrmService, ITemplateService templateService, ICampanhaWorkflowService campanhaWorkflowService)
		{
			_pessoaService = pessoaService;
			_campanhaCrmService = campanhaCrmService;
			_templateService = templateService;
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		public void VerificarStatusCampanha(Guid id)
		{
			var dadosCampanha = _campanhaWorkflowService.Get(id);
			 
			ManagerFactory.VerificarStatusCampanha(dadosCampanha.CampanhaId, dadosCampanha.Status );
		}
	}
}
