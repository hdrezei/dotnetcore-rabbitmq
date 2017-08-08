using nyom.domaincore.Models;

namespace nyom.domain.Crm.Pessoa
{
	public class PessoaService : ServiceBaseCrm<Pessoa>, IPessoaService
	{
		private readonly IPessoaRepository _pessoaRepository;
		public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}
	}
}