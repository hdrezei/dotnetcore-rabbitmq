using Microsoft.EntityFrameworkCore;
using nyom.domain.Crm.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mappings;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class WorkflowContext : DbContext
	{
		public WorkflowContext(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Workflow> Workflows { get; set; }
		public DbSet<Campanha> Campanhas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.AddConfiguration(new WorkflowMap());
			modelBuilder.AddConfiguration(new CampanhaMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}

