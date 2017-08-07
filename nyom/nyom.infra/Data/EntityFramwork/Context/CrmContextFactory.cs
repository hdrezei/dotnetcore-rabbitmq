using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class CrmContextFactory : IDbContextFactory<CrmContext>
	{
		public CrmContext Create(DbContextFactoryOptions options)
		{
			var optionsBuilder = new DbContextOptionsBuilder<CrmContext>();

			optionsBuilder.UseSqlServer("Server=mssql.crm; Database=nyom; User ID=sa; Password=nyom.crm-7410");

			return new CrmContext(optionsBuilder.Options);
		}
	}
}
