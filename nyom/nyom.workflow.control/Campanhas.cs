using System;
using System.Linq;
using System.Threading;
using nyom.domain;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.control
{
	public class Campanhas
	{
		public AutoResetEvent AutoEvent;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IDockerHelper _dockerHelper;

		public Campanhas(ICampanhaWorkflowService campanhaWorkflowService,
			IDockerHelper dockerHelper)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
			_dockerHelper = dockerHelper;
		}

		public void Start()
		{
			//AutoEvent = new AutoResetEvent(false);
			//new Timer(BuscarCampanhas, AutoEvent, 3600, 3600);
			//AutoEvent.WaitOne();

			BuscarCampanhas();
		}

		//public void BuscarCampanhas(object stateInfo)
		public void BuscarCampanhas()
		{
			var dadosCampanha = _campanhaWorkflowService.FindAll(a => a.Status.Equals(Convert.ToInt16(WorkflowStatus.Ready)))
				.OrderBy(a => a.DataCriacao).FirstOrDefault();
			if (dadosCampanha == null) return;

			_campanhaWorkflowService.AtualizarStatusCampanha(dadosCampanha.CampanhaId, WorkflowStatus.WorkflowManager);

			_dockerHelper.CriarContainerDocker(dadosCampanha.CampanhaId, "nyom.workflow.manager");
		}
	}
}