using nyom.domain.Crm.Pessoa;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class PessoaRepository : RepositoryBaseCrm<Pessoa>,IPessoaRepository
	{
		public PessoaRepository(CrmContext context) : base(context)
		{
		}
	}
}