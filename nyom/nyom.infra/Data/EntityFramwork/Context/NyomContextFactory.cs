using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class NyomContextFactory : IDbContextFactory<NyomContext>
	{
		public NyomContext Create(DbContextFactoryOptions options)
		{
			var optionsBuilder = new DbContextOptionsBuilder<NyomContext>();

			optionsBuilder.UseSqlServer("Server=localhost,1433; Database=nyom; User ID=sa; Password=nyom.7410");

			return new NyomContext(optionsBuilder.Options);
		}
	}
}
