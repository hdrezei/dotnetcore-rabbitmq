using System;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager
{
	public interface IManagerServices
	{
		void AtualizarStatusCampanha(Guid id, WorkflowStatus status);
	}
}