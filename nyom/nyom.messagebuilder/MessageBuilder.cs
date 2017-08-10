using nyom.domain.Crm.Templates;
using System;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Workflow.Campanha;

namespace nyom.messagebuilder
{
	public class MessageBuilder
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IPessoaService _pessoaService;

		
		public MessageBuilder(ITemplateService templateservice, ICampanhaWorkflowService campanhaWorkflowService, IPessoaService pessoaService)
		{
			_templateservice = templateservice;
			_campanhaWorkflowService = campanhaWorkflowService;
			_pessoaService = pessoaService;
		}

		public void MontarMensaagens(Guid campanhaId)
		{
			var dadosCampanha = _campanhaWorkflowService.Get(campanhaId);
			var dadosTemplate = _templateservice.Get(dadosCampanha.TemplateId);

			var listaPessoas = _pessoaService.All();

			foreach (var itens in listaPessoas)
			{
				
			}



		}
	}
}