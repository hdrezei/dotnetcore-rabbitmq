using System;

namespace nyom.domain.Workflow
{
    public class Workflow
    {
	    public Workflow()
	    {
		    WorkflowId = Guid.NewGuid();
	    }
		public Guid WorkflowId { get; set; }
		public Guid TemplateId { get; set; }
		public Guid CampanhaId { get; set; }
		public bool Status { get; set; }

    }
}
