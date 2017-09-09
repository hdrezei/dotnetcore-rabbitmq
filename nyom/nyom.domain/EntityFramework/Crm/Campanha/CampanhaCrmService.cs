using nyom.domain.core.EntityFramework.Models;
using nyom.domain.Crm.Campanha;

namespace nyom.domain.EntityFramework.Crm.Campanha
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