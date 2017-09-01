using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nyom.domain;
using nyom.domain.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mappings.Workflow;

namespace nyom.infra.Data.EntityFramwork.Context
{
    public class WorkflowContext : DbContext, IDbContext
    {
        private IConfiguration Configuration { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		// => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection"));
		//=> optionsBuilder.UseSqlServer("Server=mssql.workflow; Database=workflow; User ID=sa; Password=nyom.workflow-7410");

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// get the configuration from the app settings
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
			// define the database to 
			Console.WriteLine(config.GetConnectionString("WorkflowConnection"));
			optionsBuilder.UseSqlServer(config.GetConnectionString("WorkflowConnection"));
		}

		public DbSet<CampanhaWorkflow> Campanhas { get; set; }
        public DbSet<Workflow> Workflow { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CampanhaWorkflowMap());
            modelBuilder.AddConfiguration(new WorkflowMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

