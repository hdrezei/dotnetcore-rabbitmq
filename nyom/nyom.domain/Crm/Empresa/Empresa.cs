using System;

namespace nyom.domain.Crm.Empresa
{
    public class Empresa : BaseEntity
    {
	    public Empresa()
	    {
		     EmpresaId = Guid.NewGuid();
	    }

	    public Guid EmpresaId { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public string CNPJ { get; set; }
		public string RazaoSocial { get; set; }
    }
}
