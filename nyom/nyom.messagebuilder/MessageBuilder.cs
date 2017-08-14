using System;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.MongoMessage;
using nyom.domain.Workflow.Campanha;

namespace nyom.messagebuilder
{
	public class MessageBuilder
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IPessoaService _pessoaService;
		private readonly IMongoMessageService _messageService;

		public MessageBuilder()
		{
		}

		public MessageBuilder(ITemplateService templateservice, ICampanhaWorkflowService campanhaWorkflowService,
			IPessoaService pessoaService, IMongoMessageService messageService)
		{
			_templateservice = templateservice;
			_campanhaWorkflowService = campanhaWorkflowService;
			_pessoaService = pessoaService;
			_messageService = messageService;
		}

		public void MontarMensaagens(Guid campanhaId)
		{
			var dadosCampanha = _campanhaWorkflowService.Get(campanhaId);
			var dadosTemplate = _templateservice.Get(dadosCampanha.TemplateId);

			var listaPessoas = _pessoaService.All();

			foreach (var itens in listaPessoas)
			{
				var message = new Message
				{
					CampanhaId = Guid.NewGuid().ToString(),
					DataCriacao = DateTime.Now,
					DataEntregaMensagens = DateTime.Now,
					Id = Guid.NewGuid().ToString(),
					Mensagem = "Teste",
					Status = 1,
					TemplateId = dadosTemplate.TemplateId.ToString()
				};
				_messageService.Save(message);
			}
		}
	}
}