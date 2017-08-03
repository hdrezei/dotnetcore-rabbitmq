using nyom.domain.Nyom.Campanha;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class CampanhaRepository :RepositoryBase<Campanha>, ICampanhaRepository
	{
		public CampanhaRepository(NyomContext context) : base(context)
		{
		}
	}
}