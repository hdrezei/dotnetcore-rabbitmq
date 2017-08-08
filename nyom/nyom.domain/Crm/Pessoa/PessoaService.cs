using nyom.domain.Nyom.Pessoa;

namespace nyom.domain.Crm.Pessoa
{
	public class PessoaService : ServiceBaseCrm<Crm.Pessoa.Pessoa>, IPessoaService
	{
		private readonly IPessoaRepository _pessoaRepository;
		public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}
	}
}