using System;
using System.Collections.Generic;
using System.Text;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager
{
    public class ManagerServices
    {
	    private static ICampanhaWorkflowRepository _campanhaWorkflowRepository;

	    public ManagerServices(ICampanhaWorkflowRepository campanhaWorkflowRepository)
	    {
		    _campanhaWorkflowRepository = campanhaWorkflowRepository;
	    }

		public static void AtualizarStatusCampanha(Guid id, WorkflowStatus status)
	    {
		    var dadosCampanha = _campanhaWorkflowRepository.Get(id);
		    dadosCampanha.Status = status;
		    _campanhaWorkflowRepository.Save(dadosCampanha);
	    }
	}
}
