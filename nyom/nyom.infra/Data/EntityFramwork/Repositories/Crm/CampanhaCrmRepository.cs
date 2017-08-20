using nyom.domain.Crm.Campanha;

namespace nyom.infra.Data.EntityFramwork.Repositories.Crm
{
	public class CampanhaCrmRepository : RepositoryBase<CampanhaCrm>, ICampanhaCrmRepository
	{
		public CampanhaCrmRepository(IDbContext context) : base(context)
		{
		}
	}
}