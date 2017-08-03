using nyom.domain.Nyom.Empresa;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class EmpresaRepository : RepositoryBase<Empresa>,IEmpresaRepository
	{
		public EmpresaRepository(NyomContext context) : base(context)
		{
		}
	}
}