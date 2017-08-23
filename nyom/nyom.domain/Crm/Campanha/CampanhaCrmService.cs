using nyom.domain.core.EntityFramework.Models;

namespace nyom.domain.Crm.Campanha
{
	public class CampanhaCrmService : ServiceBase<CampanhaCrm> , ICampanhaCrmService
	{
		private readonly ICampanhaCrmRepository _campanhaRepository;

		public CampanhaCrmService(ICampanhaCrmRepository campanhaRepository) : base(campanhaRepository)
		{
		    _campanhaRepository = campanhaRepository;
		}
	}
}