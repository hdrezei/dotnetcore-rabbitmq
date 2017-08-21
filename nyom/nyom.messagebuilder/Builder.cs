using System;
using System.Collections.Generic;
using System.Net.Http;
using nyom.domain;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;

namespace nyom.messagebuilder
{
	public class Builder
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaCrmService _campanhaCrmService;
		private readonly IPessoaService _pessoaService;
		private readonly IMessageService _messageService;

		public Builder(ITemplateService templateservice, ICampanhaCrmService campanhaCrmService,
			IPessoaService pessoaService, IMessageService messageService)
		{
			_templateservice = templateservice;
			_campanhaCrmService = campanhaCrmService;
			_pessoaService = pessoaService;
			_messageService = messageService;
		}

		public void MontarMensagens(string campanhaId)
		{
			//var id = new Guid(campanhaId);
            var id = new Guid("6E15D6B2-CD18-4048-8746-82084FECD4EC");
			var dadosCampanha = _campanhaCrmService.Get(id);
			if (dadosCampanha == null)
				return;

			var dadosTemplate = _templateservice.Get(dadosCampanha.TemplateId);
			if (dadosTemplate == null)
				return;

			var listaPessoas = _pessoaService.All();
			if (listaPessoas == null)
				return;

			SalvarMensagens(listaPessoas, dadosCampanha, dadosTemplate);

			AtualizarStatusApi(dadosCampanha.CampanhaId);
		}

		public void AtualizarStatusApi(Guid dadosCampanhaCampanhaId)
		{
			//using (var client = new HttpClient())
			//{
			//	using (var response = client.GetAsync("http://localhost:52032/api/MessageBuilder/AtualizarCampanha/"+dadosCampanhaCampanhaId))
			//	{
			//		if (response.IsCompletedSuccessfully)
			//		{
			//			//Log positivo
			//		}
			//		else
			//		{
			//			//Log negativo
			//		}
			//	} 
			//}
		}

		private void SalvarMensagens(IEnumerable<Pessoa> listaPessoas, CampanhaCrm dadosCampanha, Template dadosTemplate)
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
					Status = WorkflowStatus.MessageBuilderCompleted,
					TemplateId = dadosTemplate.TemplateId.ToString()
				};
				_messageService.SaveOneAsync(message);
			}
		}
	}
}