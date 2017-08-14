using System;

namespace nyom.workflow.manager
{
	public interface IManagerFactory
	{
		void VerificarStatusCampanha(Guid id, Enum workflowStatus);
	}
}