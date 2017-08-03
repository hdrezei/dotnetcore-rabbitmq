using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace nyom.infra.Data.EntityFramwork.Context
{
	public class Nyom2ContextFactory : IDbContextFactory<Nyom2Context>
	{
		public Nyom2Context Create(DbContextFactoryOptions options)
		{
			var optionsBuilder = new DbContextOptionsBuilder<Nyom2Context>();

			optionsBuilder.UseSqlServer("Server=localhost; Database=nyom2; User ID=s_a; Password=nyom.7411");

			return new Nyom2Context(optionsBuilder.Options);
		}

	
	}
}
