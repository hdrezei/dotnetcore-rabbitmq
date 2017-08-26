using System;
using System.Collections.Generic;
using nyom.domain;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.MongoDb.Message;
using nyom.infra.CrossCutting.Services;

namespace nyom.messagebuilder
{
	public class Mensagens : IMensagens
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaCrmService _campanhaCrmService;
		private readonly IPessoaService _pessoaService;
		private readonly IMessageService _messageService;
		private readonly IAtualizarStatus _atualizarStatus;

		public Mensagens(ITemplateService templateservice, ICampanhaCrmService campanhaCrmService,
			IPessoaService pessoaService, IMessageService messageService, IAtualizarStatus atualizarStatus)
		{
			_templateservice = templateservice;
			_campanhaCrmService = campanhaCrmService;
			_pessoaService = pessoaService;
			_messageService = messageService;
			_atualizarStatus = atualizarStatus;
		}
		public void MontarMensagens(string campanhaId)
		{
			//var id = new Guid(campanhaId);
			var id = new Guid(campanhaId);
			var dadosCampanha = _campanhaCrmService.Get(id);
			if (dadosCampanha != null)
			{
				var dadosTemplate = _templateservice.Get(dadosCampanha.TemplateId);
				if (dadosTemplate == null)
				{
					Console.WriteLine("Nenhum template foi encontrado");
					Console.ReadKey();
					return;
				}

				var listaPessoas = _pessoaService.All();
				if (listaPessoas == null)
				{
					Console.WriteLine("Nenhuma lista de pessoas foi encontrada");
					Console.ReadKey();
					return;
				}

				SalvarMensagens(listaPessoas, dadosCampanha, dadosTemplate);
				_atualizarStatus.AtualizarStatusApi(dadosCampanha.CampanhaId, (int)WorkflowStatus.MessageBuilderCompleted);
			}
			else
			{
				Console.WriteLine("Nenhuma campanha foi encontrada");
				Console.ReadKey();
				return;
			}
		}
		public void SalvarMensagens(IEnumerable<Pessoa> listaPessoas, CampanhaCrm dadosCampanha, Template dadosTemplate)
		{
			foreach (var itens in listaPessoas)
			{
				var message = new Message
				{
					CampanhaId = dadosCampanha.CampanhaId.ToString(),
					DataCriacao = dadosCampanha.DataInicio,
					DataEntregaMensagens = DateTime.Now,
					Id = Guid.NewGuid(),
					Mensagem = dadosTemplate.Mensagem,
					Status = (int)WorkflowStatus.MessageBuilderCompleted,
					TemplateId = dadosTemplate.TemplateId.ToString()
				};
				_messageService.InsertOne(message);
			}
		}
	}
}