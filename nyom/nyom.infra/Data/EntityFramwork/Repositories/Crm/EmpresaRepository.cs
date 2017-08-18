using nyom.domain.Crm.Empresa;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class EmpresaRepository : RepositoryBaseCrm<Empresa>,IEmpresaRepository
	{
		public EmpresaRepository(CrmContext context) : base(context)
		{
		}
	}
}