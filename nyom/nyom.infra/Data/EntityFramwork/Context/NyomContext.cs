using Microsoft.EntityFrameworkCore;
using nyom.domain.Campanha;
using nyom.domain.Configuration;
using nyom.domain.Empresa;
using nyom.domain.Notifications;
using nyom.domain.Pessoa;
using nyom.domain.Templates;
using nyom.domain.Workflow;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mapping;
using nyom.infra.Data.EntityFramwork.Mappings;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class NyomContext : DbContext
	{
		public NyomContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Configuration> Configurations { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Campanha> Campanhas { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Template> Templates { get; set; }
		public DbSet<Workflow> Workflows { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddConfiguration(new ConfigurationMap());
			modelBuilder.AddConfiguration(new NotificationMap());
			modelBuilder.AddConfiguration(new CampanhaMap());
			modelBuilder.AddConfiguration(new EmpresaMap());
			modelBuilder.AddConfiguration(new PessoaMap());
			modelBuilder.AddConfiguration(new TemplateMap());
			modelBuilder.AddConfiguration(new WorkflowMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}

