using nyom.domain.core.EntityFramework.Models;

namespace nyom.domain.Crm.Pessoa
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