using nyom.domain.core.Models;
using nyom.domain.Nyom.Pessoa;

namespace nyom.domain.Crm.Pessoa
{
	public class PessoaService : ServiceBase<Crm.Pessoa.Pessoa>, IPessoaService
	{
		private readonly IPessoaRepository _pessoaRepository;
		public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}
	}
}