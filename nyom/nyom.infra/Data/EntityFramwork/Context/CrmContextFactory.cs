using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class CrmContextFactory : IDesignTimeDbContextFactory<CrmContext>
	{
		public CrmContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<CrmContext>();

			optionsBuilder.UseSqlServer("Server=localhost,1455; Database=nyom; User ID=sa; Password=nyom.crm-7410");

			return new CrmContext(optionsBuilder.Options);
		}
	}
}
