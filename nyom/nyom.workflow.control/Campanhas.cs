using System.Linq;
using System.Threading;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.workflow.manager;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.control
{
	public class Campanhas
	{
		private Timer _tm;
		private AutoResetEvent _autoEvent;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IManagerServices _managerServices;
		private readonly IDockerHelper _dockerHelper;

		public Campanhas(ICampanhaWorkflowService campanhaWorkflowService,
			IManagerServices managerServices, IDockerHelper dockerHelper)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
			_managerServices = managerServices;
			_dockerHelper = dockerHelper;
		}

		public void Start()
		{
			_autoEvent = new AutoResetEvent(false);
			_tm = new Timer(BuscarCampanhas, _autoEvent, 3600, 3600);
		}

		public void BuscarCampanhas(object stateInfo)
		{
			var dadosCampanha = _campanhaWorkflowService.FindAll(a => a.Status.Equals(WorkflowStatus.Ready))
				.OrderByDescending(a => a.DataCriacao).SingleOrDefault();
			if (dadosCampanha == null) return;
			
			_managerServices.AtualizarStatusCampanha(dadosCampanha.CampanhaId, WorkflowStatus.WorkflowManager);
			_dockerHelper.CriarContainerDocker(dadosCampanha.CampanhaId, "nyom.workflow.manager");
		}
	}
}