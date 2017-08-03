using nyom.domain.Templates;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
	{
		public TemplateRepository(NyomContext context) : base(context)
		{
		}
	}
}