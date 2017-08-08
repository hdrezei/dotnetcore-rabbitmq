using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.domaincore.Interfaces;
using nyom.domaincore.Models;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;

namespace nyom.workflow
{
	public class Program
	{
		public static IConfigurationRoot Configuration { get; set; }
		private static IServiceProvider _serviceProvider;

		// create service collection

		private static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true);
			Configuration = builder.Build();


			_serviceProvider = new ServiceCollection()
				.AddDbContext<CrmContext>(o => o.UseSqlServer(Configuration["CrmConnection"]))
				.BuildServiceProvider();

			var serviceCollection = new ServiceCollection();

			serviceCollection.AddDbContext<WorkflowContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection")));


			ConfigureServices(serviceCollection);

			// create service provider 
			var serviceProvider = serviceCollection.BuildServiceProvider();

			// entry to run app
			
		serviceProvider.GetService<Campanhas>().Start();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IWorkflowService, WorkflowService>();
			services.AddTransient<IWorkflowRepository, WorkflowRepository>();

			services.AddTransient<ITemplateService, TemplateService>();
			services.AddTransient<ITemplateRepository, TemplateRepository>();

			services.AddTransient<IPessoaService, PessoaService>();
			services.AddTransient<IPessoaRepository, PessoaRepository>();

			services.AddTransient<IEmpresaService, EmpresaService>();
			services.AddTransient<IEmpresaRepository, EmpresaRepository>();

			services.AddTransient<ICampanhaWorkflowService, CampanhaWorkflowService>();
			services.AddTransient<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();

			services.AddTransient<ICampanhaCrmService, CampanhaCrmService>();
			services.AddTransient<ICampanhaCrmRepository, CampanhaCrmRepository>();

			services.AddTransient(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			services.AddTransient(typeof(IRepositoryBaseWorkflow<>), typeof(RepositoryBaseWorkflow<>));
			services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseWorkflow<>));

			services.AddTransient<Campanhas>();
		}
	}
}