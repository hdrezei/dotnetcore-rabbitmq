using Microsoft.EntityFrameworkCore;
using nyom.domain.Configuration;
using nyom.domain.Notifications;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mapping;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class NyomContext : DbContext
	{
		public NyomContext(DbContextOptions<NyomContext> options) : base(options)
		{
		}

		public DbSet<Configuration> Configurations { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=mssql;Database=nyom;User ID=sa;Password=nyom.7410");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddConfiguration(new ConfigurationMap());
			modelBuilder.AddConfiguration(new NotificationMap());
			base.OnModelCreating(modelBuilder);
		}
	}
}

