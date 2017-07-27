using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.queuebuilder
{
    class Program
    {
	    public static IConfigurationRoot Configuration { get; set; }
	    private static IServiceProvider _serviceProvider;
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
			Configuration = builder.Build();

			//setup DI
			_serviceProvider = new ServiceCollection()
				.AddDbContext<NyomContext>(o => o.UseSqlServer(Configuration["DefaultConnection"]))
				.BuildServiceProvider();
			
		}
    }
}