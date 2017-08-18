using nyom.domain.Crm.Campanha;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class CampanhaCrmRepository : RepositoryBaseCrm<CampanhaCrm>, ICampanhaCrmRepository
	{
		public CampanhaCrmRepository(CrmContext context) : base(context)
		{
		}
	}
}