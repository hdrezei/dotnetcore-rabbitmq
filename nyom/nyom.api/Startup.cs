using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.EntityFramework.Crm.Pessoa;
using nyom.domain.EntityFramework.Crm.Templates;
using nyom.domain.EntityFramework.Workflow.Campanha;
using nyom.domain.MongoDb.Message;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories.Workflow;
using nyom.infra.Data.MongoDb.Repositories;
using nyom.infra.Factory;

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
			services.AddMvc();
			services.AddScoped<ITemplateService, TemplateService>();
			services.AddScoped<IPessoaService, PessoaService>();
			services.AddScoped<ICampanhaWorkflowService, CampanhaWorkflowService>();
			services.AddScoped<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();
			services.AddScoped<IManagerFactory, ManagerFactory>();
			services.AddScoped<IDockerHelper, DockerHelper>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			services.AddScoped(typeof(IRepositoryBase<>), typeof(infra.Data.EntityFramwork.Repositories.RepositoryBase<>));
			services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
			services.AddScoped<IDbContext, WorkflowContext>();
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
