using nyom.domain.Crm.Pessoa;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories.Crm
{
	public class PessoaRepository : RepositoryBase<Pessoa>,IPessoaRepository
	{
		public PessoaRepository(IDbContext context) : base(context)
		{
		}
	}
}