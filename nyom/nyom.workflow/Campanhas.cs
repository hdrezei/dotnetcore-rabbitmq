using System.Threading;
using nyom.domain.Crm.Templates;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow
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
			_tm = new Timer(BuscarCampanhas, _autoEvent, 1000, 1000);
		}

		public void BuscarCampanhas(object stateInfo)
		{
			var dadosCampanha = _campanhaWorkflowService.Find(a => a.Status.Equals(Status.Pronto));
			if (dadosCampanha == null) return;
			DockerHelper.Run(dadosCampanha.CampanhaId);
			DockerHelper.Inspect();
			DockerHelper.Execute();
		}
	}
}