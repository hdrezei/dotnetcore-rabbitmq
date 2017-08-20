using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nyom.domain;
using nyom.domain.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.infra.Data.EntityFramwork.Mappings.Workflow;
using CampanhaMap = nyom.infra.Data.EntityFramwork.Mappings.Crm.CampanhaMap;


namespace nyom.infra.Data.EntityFramwork.Context
{
    public class WorkflowContext : DbContext, IDbContext
    {
        public static IConfiguration Configuration { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder.UseSqlServer("Server = localhost, 1433; Database=workflow; User ID = sa; Password=nyom.workflow-7410");


        //   public CrmContext(IOptions<SqlSettings> settings)
        //   {
        //       _settings = settings;
        //   }

        public WorkflowContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CampanhaWorkflow> Campanhas { get; set; }
        public DbSet<Workflow> Workflow { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    // modelBuilder.Configurations.Add(configurationInstance);
            //    modelBuilder.ApplyConfiguration(configurationInstance);
            //}


            modelBuilder.AddConfiguration(new CampanhaWorkflowMap());
            modelBuilder.AddConfiguration(new WorkflowMap());
           

            base.OnModelCreating(modelBuilder);
        }
    }
}

