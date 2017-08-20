using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.domain.Workflow.Workflow;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.MongoDb.Repositories;
using nyom.workflow.manager.Factory;
using nyom.workflow.manager.Interfaces;

namespace nyom.api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<CrmContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("CrmConnection")));

			services.AddDbContext<WorkflowContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection")));

			services.AddMvc();

			//services.AddScoped<IWorkflowService, WorkflowService>();
			//services.AddScoped<IWorkflowRepository, WorkflowRepository>();
			services.AddScoped<ITemplateService, TemplateService>();
			//services.AddScoped<ITemplateRepository, TemplateRepository>();
			services.AddScoped<IPessoaService, PessoaService>();
			//services.AddScoped<IPessoaRepository, PessoaRepository>();
			//services.AddScoped<IEmpresaService, EmpresaService>();
			//services.AddScoped<IEmpresaRepository, EmpresaRepository>();
			services.AddScoped<ICampanhaWorkflowService, CampanhaWorkflowService>();
			//services.AddScoped<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();
			services.AddScoped<ICampanhaCrmService, CampanhaCrmService>();
			//services.AddScoped<ICampanhaCrmRepository, CampanhaCrmRepository>();
			services.AddScoped<IManagerFactory, ManagerFactory>();
			//services.AddScoped<IManagerServices, ManagerServices>();
			services.AddScoped<IMessageService, MessageService>();
			services.AddScoped<IDockerHelper, DockerHelper>();
			
			//services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			//services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
			//services.AddScoped(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			//services.AddScoped(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			//services.AddScoped(typeof(IRepositoryBaseWorkflow<>), typeof(RepositoryBaseWorkflow<>));
			

			//services.AddScoped(typeof(IMessageRepository), typeof(RepositoryBase<Message>));
			services.AddScoped<IMessageRepository, MessageRepository>();
			////services.Configure<IOptions<MongoDbSettings>>(
			////	(o) => new MessageRepository(o, Environment.GetEnvironmentVariable("CAMPANHA")));

		}
	
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseExceptionHandler("/Home/Error");

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					"default",
					"{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
