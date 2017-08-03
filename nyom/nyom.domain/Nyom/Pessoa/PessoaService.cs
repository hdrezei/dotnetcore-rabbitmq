using nyom.domain.core.Models;


namespace nyom.domain.Nyom.Pessoa
{
	public class PessoaService : ServiceBase<Pessoa>, IPessoaService
	{
		private readonly IPessoaRepository _pessoaRepository;
		public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}
	}
}