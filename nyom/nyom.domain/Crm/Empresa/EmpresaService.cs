namespace nyom.domain.Crm.Empresa
{
	public class EmpresaService : ServiceBaseCrm<Crm.Empresa.Empresa>, IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}
	}
}