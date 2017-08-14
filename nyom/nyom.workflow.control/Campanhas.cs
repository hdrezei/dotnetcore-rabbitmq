using System.Threading;
using nyom.domain.Crm.Templates;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.workflow.manager;

namespace nyom.workflow.control
{
	public class Campanhas
	{
		private Timer _tm;
		private AutoResetEvent _autoEvent;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IManagerFactory _managerFactory;

		public Campanhas(ICampanhaWorkflowService campanhaWorkflowService, IManagerFactory managerFactory)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
			_managerFactory = managerFactory;
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
				_managerFactory.VerificarStatusCampanha(item.CampanhaId, item.Status);
			}
		}
	}
}