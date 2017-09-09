using nyom.domain.core.EntityFramework.Models;
using nyom.domain.Crm.Empresa;

namespace nyom.domain.EntityFramework.Crm.Empresa
{
	public class EmpresaService : ServiceBase<domain.Crm.Empresa.Empresa>, IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}
	}
}