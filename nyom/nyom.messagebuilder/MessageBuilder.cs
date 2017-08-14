using System;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.workflow.manager;
using static nyom.infra.CrossCutting.Helper.WorkflowStatus;

namespace nyom.messagebuilder
{
	public class MessageBuilder
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IPessoaService _pessoaService;
		private readonly IMessageService _messageService;
		private readonly IManagerServices _managerServices;

		public MessageBuilder(ITemplateService templateservice, ICampanhaWorkflowService campanhaWorkflowService,
			IPessoaService pessoaService, IMessageService messageService, IManagerServices managerServices)
		{
			_templateservice = templateservice;
			_campanhaWorkflowService = campanhaWorkflowService;
			_pessoaService = pessoaService;
			_messageService = messageService;
			_managerServices = managerServices;
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
					Status = MessageBuilderCompleted,
					TemplateId = dadosTemplate.TemplateId.ToString()
				};
				_messageService.Save(message);
			}

			_managerServices.AtualizarStatusCampanha(dadosCampanha.CampanhaId, MessageBuilderCompleted);
		}
	}
}