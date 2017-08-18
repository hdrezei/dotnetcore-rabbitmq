using System;
using System.Collections;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.Interfaces;

namespace nyom.domain.Workflow.Campanha
{
	public interface ICampanhaWorkflowService : IServiceBaseCrm<CampanhaWorkflow>
	{
		void AtualizarStatusCampanha(Guid id, WorkflowStatus status);
	}
}