using nyom.domain.Workflow;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class WorkflowRepository : RepositoryBase<Workflow>
	{
		public WorkflowRepository(NyomContext context) : base(context)
		{
		}
	}
}