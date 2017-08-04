using System;

namespace nyom.domain.Crm.Templates
{
    public class Template
    {
	    public Template()
	    {
		    TemplateId = Guid.NewGuid();
	    }

	    public Guid TemplateId { get; set; }
		public string Nome { get; set; }
		public DateTime DataCriacao { get; set; }
		public bool Status { get; set; }
    }
}
