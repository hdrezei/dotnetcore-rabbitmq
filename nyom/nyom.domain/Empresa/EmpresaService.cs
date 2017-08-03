using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;

namespace nyom.domain.Empresa
{
	public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}
	}
}