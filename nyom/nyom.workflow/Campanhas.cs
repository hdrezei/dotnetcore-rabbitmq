using System;
using System.Threading;
using nyom.domain.Workflow.Campanha;

namespace nyom.workflow
{
	public class Campanhas
	{
		private Timer _tm;

		private AutoResetEvent _autoEvent;

		private readonly ICampanhaWorkflowService _campanhaService;

		public Campanhas(ICampanhaWorkflowService campanhaService)
		{
			_campanhaService = campanhaService;

		}

		public void StartTimer()
		{
			_autoEvent = new AutoResetEvent(false);
			_tm = new Timer(BuscarCampanhas, _autoEvent, 1000, 1000);
			
		}

		public void BuscarCampanhas(object stateInfo)
		{
			Console.WriteLine("Teste");
		}
	}
}

