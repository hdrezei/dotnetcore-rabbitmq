using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mappings.Crm;


namespace nyom.infra.Data.EntityFramwork.Context
{
	public class CrmContext : DbContext
	{
		private IOptions<ContextSettings> _settings;

		public CrmContext(DbContextOptions options) : base(options)
		{
		}

		public CrmContext(IOptions<ContextSettings> settings, DbContextOptions options):base(options)
		{
			this._settings = settings;
		}

		public DbSet<CampanhaCrm> Campanhas { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Template> Templates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddConfiguration(new CampanhaMap());
			modelBuilder.AddConfiguration(new EmpresaMap());
			modelBuilder.AddConfiguration(new PessoaMap());
			modelBuilder.AddConfiguration(new TemplateMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}

