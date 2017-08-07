using nyom.domain.core.Models;

namespace nyom.domain.Crm.Campanha
{
	public class CampanhaService : ServiceBaseCrm<Crm.Campanha.Campanha> , ICampanhaService
	{
		private readonly ICampanhaRepository _campanhaRepository;
		public CampanhaService(ICampanhaRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
	}
}