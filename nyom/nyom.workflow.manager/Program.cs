using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.core.Interfaces;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;
using nyom.infra.Data.MongoDb.Repositories;
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

			_serviceProvider = new ServiceCollection()
				.AddDbContext<CrmContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CrmConnection")))
				.BuildServiceProvider();

			var serviceCollection = new ServiceCollection();

			serviceCollection.AddDbContext<WorkflowContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection")));

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
			services.AddScoped(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			services.AddScoped(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			services.AddScoped(typeof(IRepositoryBaseWorkflow<>), typeof(RepositoryBaseWorkflow<>));
			services.AddScoped(typeof(IServiceBaseWorkflow<>), typeof(ServiceBaseWorkflow<>));
			services.AddScoped<ManagerServices>();
		}
	}
}