using nyom.domain.Crm.Templates;
using nyom.domain.EntityFramework.Crm.Templates;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories.Crm
{
	public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
	{
		public TemplateRepository(IDbContext context) : base(context)
		{
		}
	}
}