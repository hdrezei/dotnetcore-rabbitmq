using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nyom.domain;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mappings.Crm;


namespace nyom.infra.Data.EntityFramwork.Context
{
	public class CrmContext : DbContext, IDbContext
	{
	    public static IConfiguration Configuration { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
	    {
	        return base.Set<TEntity>();
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	        //=> optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CrmConnection"));
	        => optionsBuilder.UseSqlServer("Server=localhost,1455; Database=crm; User ID=sa; Password=nyom.crm-7410");

    //   public CrmContext(IOptions<SqlSettings> settings)
    //   {
    //       _settings = settings;
    //   }

    //public CrmContext(DbContextOptions options) : base(options)
    //{
    //}

    public DbSet<CampanhaCrm> Campanhas { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Template> Templates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //   // modelBuilder.Configurations.Add(configurationInstance);
            //    modelBuilder.ApplyConfiguration(configurationInstance);
            //}


            modelBuilder.AddConfiguration(new CampanhaMap());
            modelBuilder.AddConfiguration(new EmpresaMap());
            modelBuilder.AddConfiguration(new PessoaMap());
            modelBuilder.AddConfiguration(new TemplateMap());

            base.OnModelCreating(modelBuilder);
		}
	}
}

