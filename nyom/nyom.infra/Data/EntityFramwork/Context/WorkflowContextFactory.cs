using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class WorkflowContextFactory : IDesignTimeDbContextFactory<WorkflowContext>
	{
		//public WorkflowContext Create(DbContextFactoryOptions options)
		//{
			
		//}

		public WorkflowContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<WorkflowContext>();

			optionsBuilder.UseSqlServer("Server=localhost,1433; Database=workflow; User ID=sa; Password=nyom.workflow-7410");

			return new WorkflowContext(optionsBuilder.Options);
		}
	}
}
