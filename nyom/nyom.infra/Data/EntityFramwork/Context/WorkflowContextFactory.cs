using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class WorkflowContextFactory : IDbContextFactory<WorkflowContext>
	{
		public WorkflowContext Create(DbContextFactoryOptions options)
		{
			var optionsBuilder = new DbContextOptionsBuilder<WorkflowContext>();

			optionsBuilder.UseSqlServer("Server=localhost,1433; Database=workflow; User ID=sa; Password=nyom.workflow-7410");

			return new WorkflowContext(optionsBuilder.Options);
		}
	}
}
