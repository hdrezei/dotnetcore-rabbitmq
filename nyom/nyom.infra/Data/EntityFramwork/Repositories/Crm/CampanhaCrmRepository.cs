using nyom.domain.Crm.Campanha;
using nyom.domain.EntityFramework.Crm.Campanha;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories.Crm
{
	public class CampanhaCrmRepository : RepositoryBase<CampanhaCrm>, ICampanhaCrmRepository
	{
		public CampanhaCrmRepository(IDbContext context) : base(context)
		{
		}
	}
}