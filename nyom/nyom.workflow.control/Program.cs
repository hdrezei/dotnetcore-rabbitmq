using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.Workflow.Campanha;
using nyom.infra;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories.Workflow;
using nyom.workflow.manager.Factory;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.control
{
	public class Program
	{
		private static IServiceProvider _serviceProvider;

		public Program(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public static IConfiguration Configuration { get; set; }
		// create service collection

		private static void Main()
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true);
			Configuration = builder.Build();

		   

            var serviceCollection = new ServiceCollection();
			
			ConfigureServices(serviceCollection);
			
			var serviceProvider = serviceCollection.BuildServiceProvider();

			serviceProvider.GetService<Campanhas>().Start();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
		    services.AddDbContext<WorkflowContext>(options =>
		        options.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection")));

            services.AddScoped<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();
			services.AddScoped<ICampanhaWorkflowService, CampanhaWorkflowService>();
			services.AddScoped<IManagerFactory, ManagerFactory>();
			services.AddScoped<IDockerHelper, DockerHelper>();
			services.AddScoped(typeof(domain.core.EntityFramework.Interfaces.IServiceBase<>), typeof(domain.core.EntityFramework.Models.ServiceBase<>));
			services.AddTransient<IDbContext, WorkflowContext>();
            services.AddScoped<Campanhas>();
		}
	}
}