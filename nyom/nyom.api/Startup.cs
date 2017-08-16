using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.Message;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.MongoDb.Repositories;

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

			//services.AddTransient<IWorkflowService, WorkflowService>();
			//services.AddTransient<IWorkflowRepository, WorkflowRepository>();
			//services.AddTransient<ITemplateService, TemplateService>();
			//services.AddTransient<ITemplateRepository, TemplateRepository>();
			//services.AddTransient<IPessoaService, PessoaService>();
			//services.AddTransient<IPessoaRepository, PessoaRepository>();
			//services.AddTransient<IEmpresaService, EmpresaService>();
			//services.AddTransient<IEmpresaRepository, EmpresaRepository>();
			//services.AddTransient<ICampanhaWorkflowService, CampanhaWorkflowService>();
			//services.AddTransient<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();
			//services.AddTransient<ICampanhaCrmService, CampanhaCrmService>();
			//services.AddTransient<ICampanhaCrmRepository, CampanhaCrmRepository>();
			//services.AddTransient<IManagerFactory, ManagerFactory>();
			//services.AddTransient<IManagerServices, ManagerServices>();
			services.AddScoped<IMessageService, MessageServices>();
			//services.AddTransient<IDockerHelper, DockerHelper>();
			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			//services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
			//services.AddTransient(typeof(IRepositoryBaseCrm<>), typeof(RepositoryBaseCrm<>));
			//services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseCrm<>));
			//services.AddTransient(typeof(IRepositoryBaseWorkflow<>), typeof(RepositoryBaseWorkflow<>));
			//services.AddTransient(typeof(IServiceBaseCrm<>), typeof(ServiceBaseWorkflow<>));



			
			

			
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
