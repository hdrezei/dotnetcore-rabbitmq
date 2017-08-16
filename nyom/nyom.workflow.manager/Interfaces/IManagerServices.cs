using System;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager.Interfaces
{
	public interface IManagerServices
	{
		void AtualizarStatusCampanha(Guid id, WorkflowStatus status);
	}
}