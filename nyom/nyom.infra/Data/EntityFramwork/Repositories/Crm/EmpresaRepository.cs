using nyom.domain.Crm.Empresa;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories.Crm
{
	public class EmpresaRepository : RepositoryBase<Empresa>,IEmpresaRepository
	{
		public EmpresaRepository(IDbContext context) : base(context)
		{
		}
	}
}