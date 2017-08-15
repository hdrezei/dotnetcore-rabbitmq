using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.core.MongoDb.Repository.Models;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;
using nyom.infra.Data.MongoDb.Repositories;
using nyom.workflow.manager;

namespace nyom.workflow.control
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
			services.AddTransient(typeof(IManagerFactory), typeof(ManagerFactory));
			services.AddTransient(typeof(IManagerServices), typeof(ManagerServices));
			services.AddTransient(typeof(IMessageService), typeof(MessageServices));
			services.AddTransient(typeof(IDockerHelper), typeof(DockerHelper));
			services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
			services.AddTransient(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			services.AddTransient(typeof(IRepositoryBaseWorkflow<>), typeof(RepositoryBaseWorkflow<>));
			services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseWorkflow<>));

			services.AddTransient<Campanhas>();
		}
	}
}