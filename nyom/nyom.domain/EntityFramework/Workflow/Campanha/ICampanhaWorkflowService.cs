using System;
using nyom.domain.core.EntityFramework.Interfaces;

namespace nyom.domain.EntityFramework.Workflow.Campanha
{
	public interface ICampanhaWorkflowService : IServiceBase<CampanhaWorkflow>
	{
		void AtualizarStatusCampanha(Guid id, WorkflowStatus status);
	}
}