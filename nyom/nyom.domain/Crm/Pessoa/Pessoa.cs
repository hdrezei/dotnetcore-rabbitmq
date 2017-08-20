using System;

namespace nyom.domain.Crm.Pessoa
{
    public class Pessoa : BaseEntity
    {
	    public Pessoa()
	    {
		     PessoaId = Guid.NewGuid();
	    }

	    public Guid PessoaId { get; set; }
	    public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string CPF { get; set; }
	    public string Telefone { get; set; }
		public string Email { get; set; }
		public string Endereco { get; set; }
	    public string Bairro { get; set; }
	    public string CEP { get; set; }	
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public Guid CampanhaId { get; set; }
	}
}
