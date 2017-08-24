using System;

namespace nyom.domain.Crm.Templates
{
    public class Template : BaseEntity
    {
	    public Template()
	    {
		    TemplateId = Guid.NewGuid();
	    }

	    public Guid TemplateId { get; set; }
		public string Nome { get; set; }
		public DateTime DataCriacao { get; set; }
		public int Status { get; set; }
		public string Mensagem { get; set; }
    }
}
