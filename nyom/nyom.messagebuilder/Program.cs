using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.core.Interfaces;
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
using nyom.infra.Data.MongoDb.Settings;
using nyom.workflow.manager.Factory;
using nyom.workflow.manager.Interfaces;
using nyom.workflow.manager.Services;

namespace nyom.messagebuilder
{
	public class Program
	{
		private static IServiceProvider _serviceProvider;
		private static object _context;

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

			serviceProvider.GetService<Builder>().MontarMensagens(Environment.GetEnvironmentVariable("CAMPANHA"));
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ITemplateService, TemplateService>();
			services.AddScoped<ITemplateRepository, TemplateRepository>();
			services.AddScoped<IPessoaService, PessoaService>();
			services.AddScoped<IPessoaRepository, PessoaRepository>();
			services.AddScoped<ICampanhaCrmService, CampanhaCrmService>();
			services.AddScoped<ICampanhaCrmRepository, CampanhaCrmRepository>();
			services.AddScoped<IManagerFactory, ManagerFactory>();
			services.AddScoped<IMessageService, MessageService>();
			services.AddScoped<IDockerHelper, DockerHelper>();
			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			services.AddScoped(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
			services.AddScoped(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			services.AddScoped<Builder>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			services.Configure<CrmContext>((o) => new TemplateRepository(o));
		}
	}
}