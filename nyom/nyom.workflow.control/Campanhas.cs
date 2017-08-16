using System.Threading;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.messagebuilder;
using nyom.workflow.manager;

namespace nyom.workflow.control
{
	public class Campanhas
	{
		private Timer _tm;
		private AutoResetEvent _autoEvent;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IManagerFactory _managerFactory;
		private readonly IMessageService _messageService;

		public Campanhas(ICampanhaWorkflowService campanhaWorkflowService, IManagerFactory managerFactory, IMessageService messageService)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
			_managerFactory = managerFactory;
			_messageService = messageService;
		}

		public void Start()
		{
			TesteEscrita te = new TesteEscrita(_messageService);
			te.TesteEscritaMongo();

			//_autoEvent = new AutoResetEvent(false);
			//_tm = new Timer(, _autoEvent, 3600, 3600);


		}

		public void BuscarCampanhas(object stateInfo)
		{
			var dadosCampanha = _campanhaWorkflowService.All();
			if (dadosCampanha == null) return;
			foreach (var item in dadosCampanha)
			{
				_managerFactory.VerificarStatusCampanha(item.CampanhaId, item.Status);
			}
		}
	}
}