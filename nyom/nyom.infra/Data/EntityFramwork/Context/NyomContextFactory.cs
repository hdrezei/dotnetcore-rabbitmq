using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace nyom.infra.Data.EntityFramwork.Context
{
    public class NyomContextFactory : IDbContextFactory<NyomContext>
    {
	    private IConfigurationRoot configuration;
	    //public NyomContextFactory()
	    //{
		   // var builder = new ConfigurationBuilder()
			  //  .SetBasePath(System.AppContext.BaseDirectory)
			  //  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

		   // configuration = builder.Build();
	    //}
		public NyomContext Create(DbContextFactoryOptions options)
	    {
			var optionsBuilder = new DbContextOptionsBuilder<NyomContext>();
			optionsBuilder.UseSqlServer(@"Server=mssql;Database=nyom;User ID=sa;Password=nyom.7410");

			return new NyomContext(optionsBuilder.Options);
		}
    }
}
