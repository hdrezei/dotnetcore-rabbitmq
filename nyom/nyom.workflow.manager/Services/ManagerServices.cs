using System;
using System.Threading;
using nyom.infra.Factory;

namespace nyom.workflow.manager.Services
{
	public class ManagerServices 
	{
		public AutoResetEvent AutoEvent;
		private static IManagerFactory _managerFactory;

	    public ManagerServices( IManagerFactory managerFactory)
	    {
			_managerFactory = managerFactory;
	    }

		public void Start(string id)
		{
			AutoEvent = new AutoResetEvent(false);
			new Timer(VerificarCampanha, AutoEvent, 0, 36000);
			AutoEvent.WaitOne();
		}



		public void VerificarCampanha(object stateInfo)
		{
			_managerFactory.VerificarStatusCampanha();

		}


	}
}
