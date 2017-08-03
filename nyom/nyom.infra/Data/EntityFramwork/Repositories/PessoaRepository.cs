using nyom.domain.Nyom.Pessoa;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class PessoaRepository : RepositoryBase<Pessoa>,IPessoaRepository
	{
		public PessoaRepository(NyomContext context) : base(context)
		{
		}
	}
}