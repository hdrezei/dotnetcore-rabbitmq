using System;
using System.Linq;
using nyom.domain;
using nyom.domain.EntityFramework.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Initializers
{
    public class EntityFrameworkWorkflowInitializer
    {
	    public static void Initialize(WorkflowContext context)
	    {
		    //context.Database.EnsureCreated();

			if (context.Campanhas.Any())
			{
				return;   
			}

		    Guid campanhaId = Guid.NewGuid();
		    Guid workflowId = Guid.NewGuid();
		    Guid templateId = Guid.NewGuid();

		    var campanha = new CampanhaWorkflow()
		    {
			    CampanhaId = campanhaId,
				DataCriacao = DateTime.Now,
			    DataInicio = DateTime.Now,
			    Nome = "Campanha de Teste",
			    Publico = 100,
			    Status = (int) WorkflowStatus.Ready,
			    TemplateId = templateId
			};

			context.Campanhas.AddRange(campanha);

		    if (context.Workflow.Any())
		    {
			    return;
		    }

		    var workflow = new Workflow()
		    {
			    CampanhaId = campanhaId,
			    Publico = 100,
			    Status = (int) WorkflowStatus.Ready,
			    TemplateId = templateId,
			    WorkflowId = workflowId
		    };

			context.Workflow.AddRange(workflow);
		    context.SaveChanges();
	    }
    }
}
