﻿using System;

namespace nyom.domain.Workflow.Campanha
{
    public class CampanhaWorkflow
    {
	    public CampanhaWorkflow()
	    {
		    CampanhaId = Guid.NewGuid();
	    }
	    public Guid CampanhaId { get; set; }
	    public string Nome { get; set; }
	    public DateTime DataInicio { get; set; }
	    public Enum Status { get; set; }
	    public Guid TemplateId { get; set; }
	    public int Publico { get; set; }
	}
}