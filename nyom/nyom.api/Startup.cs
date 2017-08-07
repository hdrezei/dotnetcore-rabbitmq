using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;
using nyom.domain.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;
using nyom.queuebuilder;
using nyom.workflow;

namespace nyom.api
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", false, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<CrmContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("CrmConnection")));

			services.AddDbContext<WorkflowContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection")));

			services.AddTransient<IWorkflowService, WorkflowService>();
			services.AddTransient<IWorkflowRepository, WorkflowRepository>();
			services.AddTransient(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			services.AddTransient(typeof(IRepositoryBaseWorkflow<>), typeof(RepositoryBaseWorkflow<>));
			services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseWorkflow<>));

			services.AddTransient<Campanhas>();

			var serviceCollection = new ServiceCollection();
			var serviceProvider = serviceCollection.BuildServiceProvider();
			serviceProvider.GetService<Campanhas>().BuscaCampanha();

			// Add framework services.
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}
