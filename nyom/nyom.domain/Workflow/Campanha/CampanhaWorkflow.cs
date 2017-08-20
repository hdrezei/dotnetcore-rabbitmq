using System;
using System.ComponentModel.DataAnnotations;


namespace nyom.domain.Workflow.Campanha
{
    public class CampanhaWorkflow : BaseEntity
    {
	    public CampanhaWorkflow()
	    {
		    CampanhaId = Guid.NewGuid();
	    }

		[Key]
	    public Guid CampanhaId { get; set; }
	    public string Nome { get; set; }
	    public DateTime DataInicio { get; set; }
	    public Guid TemplateId { get; set; }
	    public int Publico { get; set; }
	    public int Status { get; set; }
	    public DateTime DataCriacao { get; set; }
    }
}
