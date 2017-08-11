using nyom.domain.core.EntityFramework.Models;
using nyom.domain.core.Models;

namespace nyom.domain.Crm.Campanha
{
	public class CampanhaCrmService : ServiceBaseCrm<CampanhaCrm> , ICampanhaCrmService
	{
		private readonly ICampanhaCrmRepository _campanhaRepository;
		public CampanhaCrmService(ICampanhaCrmRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
	}
}