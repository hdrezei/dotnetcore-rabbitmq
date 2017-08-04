using Microsoft.EntityFrameworkCore;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Configuration;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Notifications;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Nyom.Pessoa;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mapping;
using nyom.infra.Data.EntityFramwork.Mappings;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class CrmContext : DbContext
	{
		public CrmContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Configuration> Configurations { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Campanha> Campanhas { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddConfiguration(new ConfigurationMap());
			modelBuilder.AddConfiguration(new NotificationMap());
			modelBuilder.AddConfiguration(new CampanhaMap());
			modelBuilder.AddConfiguration(new EmpresaMap());
			modelBuilder.AddConfiguration(new PessoaMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}

