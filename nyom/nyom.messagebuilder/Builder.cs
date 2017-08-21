using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using nyom.domain;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.infra.CrossCutting.Services;

namespace nyom.messagebuilder
{
	public class Builder
	{
		private readonly ITemplateService _templateservice;
		private readonly ICampanhaCrmService _campanhaCrmService;
		private readonly IPessoaService _pessoaService;
		private readonly IMessageService _messageService;
		private readonly IAtualizarStatus _atualizarStatus;

		public Builder(ITemplateService templateservice, ICampanhaCrmService campanhaCrmService,
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
			var id = new Guid("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060");
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
				_atualizarStatus.AtualizarStatusApi(dadosCampanha.CampanhaId, (int) WorkflowStatus.MessageBuilderCompleted);
			}
			else
			{
				Console.WriteLine("Nenhuma campanha foi encontrada");
				Console.ReadKey();
				return;
			}
		}

		public async Task AtualizarStatusApi(Guid dadosCampanhaCampanhaId,int status)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:5000/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = await client.GetAsync("api/campanha?id=" + dadosCampanhaCampanhaId+"&status="+status);
				Console.WriteLine(response.IsSuccessStatusCode ? "Status alterado com sucesso" : "Erro na alteração do Status");
				Console.ReadKey();
			}
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
					Id = dadosCampanha.CampanhaId.ToString(),
					Mensagem = dadosTemplate.Mensagem,
					Status = WorkflowStatus.MessageBuilderCompleted,
					TemplateId = dadosTemplate.TemplateId.ToString()
				};
				_messageService.SaveOneAsync(message);
			}
		}
	}
}