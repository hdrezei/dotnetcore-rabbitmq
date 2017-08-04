using nyom.domain.Crm.Templates;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class TemplateRepository : RepositoryBaseCrm<Template>, ITemplateRepository
	{
		public TemplateRepository(CrmContext context) : base(context)
		{
		}
	}
}