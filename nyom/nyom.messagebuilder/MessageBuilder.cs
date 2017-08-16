using System;
using System.Collections.Generic;
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

		public void MontarMensagens(Guid campanhaId)
		{
			var dadosCampanha = _campanhaWorkflowService.Get(campanhaId);
			if (dadosCampanha == null)
				return;

			var dadosTemplate = _templateservice.Get(dadosCampanha.TemplateId);
			if (dadosTemplate == null)
				return;

			var listaPessoas = _pessoaService.All();
			if (listaPessoas == null)
				return;

			SalvarMensagens(listaPessoas, dadosCampanha, dadosTemplate);

			_managerServices.AtualizarStatusCampanha(dadosCampanha.CampanhaId, MessageBuilderCompleted);
		}

		private void SalvarMensagens(IEnumerable<Pessoa> listaPessoas, CampanhaWorkflow dadosCampanha, Template dadosTemplate)
		{
			foreach (var itens in listaPessoas)
			{
				var message = new Message
				{
					CampanhaId = dadosCampanha.CampanhaId.ToString(),
					DataCriacao = dadosCampanha.DataInicio,
					DataEntregaMensagens = DateTime.Now,
					Id = dadosCampanha.CampanhaId.ToString(),
					Mensagem = dadosTemplate.Mensagem,
					Status = MessageBuilderCompleted,
					TemplateId = dadosTemplate.TemplateId.ToString()
				};
				_messageService.SaveOneAsync(message);
			}
		}
	}
}