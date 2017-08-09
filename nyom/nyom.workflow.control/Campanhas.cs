using System.Threading;
using nyom.domain.Crm.Templates;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.control
{
	public class Campanhas
	{
		private Timer _tm;
		private AutoResetEvent _autoEvent;
		private readonly ITemplateService _templateService;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;

		public Campanhas(ITemplateService templateService, ICampanhaWorkflowService campanhaWorkflowService)
		{
			_templateService = templateService;
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		public void Start()
		{
			_autoEvent = new AutoResetEvent(false);
			_tm = new Timer(BuscarCampanhas, _autoEvent, 3600, 3600);
		}

		public void BuscarCampanhas(object stateInfo)
		{
			var dadosCampanha = _campanhaWorkflowService.FindAll(a => a.Status.Equals(WorkflowStatus.Ready));
			if (dadosCampanha == null) return;
			foreach (var item in dadosCampanha)
			{
				DockerHelper.Run(item.CampanhaId,"nyom.workflow.manager");
				DockerHelper.Inspect("nyom.workflow.manager");
				DockerHelper.Execute("nyom.workflow.manager");
			}
		}
	}
}