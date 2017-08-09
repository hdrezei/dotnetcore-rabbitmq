using nyom.domain.Crm.Templates;
using System;
using nyom.domain.Workflow.Campanha;

namespace nyom.messagebuilder
{
	public class MessageBuilder
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;

		public MessageBuilder(ICampanhaWorkflowService campanhaWorkflowService)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		public MessageBuilder(ITemplateService templateservice, ICampanhaWorkflowService campanhaWorkflowService)
		{
			_templateservice = templateservice;
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		public void MontarMensaagens(Guid campanhaId)
		{
			var dadosCampanha = _campanhaWorkflowService.FindAll(a=>a.CampanhaId.Equals(campanhaId));

		}
	}
}