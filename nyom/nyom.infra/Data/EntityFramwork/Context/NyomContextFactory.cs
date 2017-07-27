using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace nyom.infra.Data.EntityFramwork.Context
{
    public class NyomContextFactory : IDbContextFactory<NyomContext>
    {
		
		
	    public NyomContext Create(DbContextFactoryOptions options)
	    {
		    var optionsBuilder = new DbContextOptionsBuilder<NyomContext>();
		   
		    optionsBuilder.UseSqlServer("Server=localhost; Database=nyom; User ID=sa; Password=nyom.7410");

		    return new NyomContext(optionsBuilder.Options);
		}
       
    }
}
