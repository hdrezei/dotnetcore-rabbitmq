using nyom.domain.core.Models;

namespace nyom.domain.Crm.Empresa
{
	public class EmpresaService : ServiceBaseCrm<Empresa>, IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}
	}
}