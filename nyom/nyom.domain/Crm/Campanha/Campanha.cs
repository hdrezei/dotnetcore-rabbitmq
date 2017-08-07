using System;

namespace nyom.domain.Crm.Campanha
{
    public class Campanha
    {
	    public Campanha()
	    {
		    CampanhaId = Guid.NewGuid();
	    }
		public Guid CampanhaId { get; set; }
		public string Nome { get; set; }
		public DateTime DataInicio { get; set; }
		public int Status { get; set; }
		public Guid TemplateId { get; set; }
	    public int Publico { get; set; }
    }
}
