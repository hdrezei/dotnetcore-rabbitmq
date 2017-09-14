using System;
using System.Linq;
using System.Threading;
using nyom.domain;
using nyom.domain.EntityFramework.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.CrossCutting.Services;

namespace nyom.workflow.control
{
	public class WorkflowControl
	{
		public AutoResetEvent AutoEvent;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IAtualizarStatus _atualizarStatus;
		private readonly IDockerHelper _dockerHelper;

		public WorkflowControl(ICampanhaWorkflowService campanhaWorkflowService, IAtualizarStatus atualizarStatus, IDockerHelper dockerHelper)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
			_atualizarStatus = atualizarStatus;
			_dockerHelper = dockerHelper;
		}

		public void Start()
		{
			AutoEvent = new AutoResetEvent(false);
			new Timer(BuscarCampanhas, AutoEvent, 0, 36000);
			AutoEvent.WaitOne();
		}

		public void BuscarCampanhas(object stateInfo)
		{
			Console.WriteLine("Bem vindo ao Nyom ");
			var dadosCampanha = _campanhaWorkflowService.FindAll(a => a.Status.Equals(Convert.ToInt16(WorkflowStatus.Ready)))
				.OrderBy(a => a.DataCriacao).FirstOrDefault();
			if (dadosCampanha == null)
			{
				Console.WriteLine("Não há campanhas");
				return;
			}

			_atualizarStatus.AtualizarStatusApi(dadosCampanha.CampanhaId, (int)WorkflowStatus.WorkflowManager);
			_dockerHelper.RunAsync(dadosCampanha.CampanhaId, "nyom.workflow.manager");
			Console.WriteLine("Campanha encontrada, iniciando Workflow Manager");
		}
	}
}