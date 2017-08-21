using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.Workflow.Campanha;
using nyom.infra;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;
using nyom.infra.Data.EntityFramwork.Repositories.Workflow;
using nyom.workflow.manager.Factory;
using nyom.workflow.manager.Interfaces;
using nyom.workflow.manager.Services;

namespace nyom.workflow.manager
{
	public class Program
	{
		private static IServiceProvider _serviceProvider;

		public Program(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public static IConfiguration Configuration { get; set; }
		
		private static void Main()
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true);
			Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();

			ConfigureServices(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();

			serviceProvider.GetService<ManagerServices>().Start(Environment.GetEnvironmentVariable("CAMPANHA"));
		}

		private static void ConfigureServices(IServiceCollection services)
		{
            services.AddScoped<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();
			services.AddScoped<ICampanhaWorkflowService, CampanhaWorkflowService>();
			services.AddScoped<IManagerFactory, ManagerFactory>();
			services.AddScoped<IDockerHelper, DockerHelper>();
			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
		    services.AddScoped<IDbContext, WorkflowContext>();
			services.AddScoped<ManagerServices>();
		}
	}
}