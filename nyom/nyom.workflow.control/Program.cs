using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.EntityFramework.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.CrossCutting.Services;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories.Workflow;
using nyom.infra.Factory;

namespace nyom.workflow.control
{
	public class Program
	{
		public static IConfigurationRoot Configuration { get; set; }
		
		private static void Main()
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true);
			Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			var serviceProvider = serviceCollection.BuildServiceProvider();
			serviceProvider.GetService<WorkflowControl>().Start();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ICampanhaWorkflowRepository, CampanhaWorkflowRepository>();
			services.AddScoped<ICampanhaWorkflowService, CampanhaWorkflowService>();
			services.AddScoped<IManagerFactory, ManagerFactory>();
			services.AddScoped<IAtualizarStatus, AtualizarStatus>();
			services.AddScoped<IDockerHelper, DockerHelper>();
			services.AddScoped(typeof(domain.core.EntityFramework.Interfaces.IServiceBase<>), typeof(domain.core.EntityFramework.Models.ServiceBase<>));
			services.AddTransient<IDbContext, WorkflowContext>();
            services.AddScoped<WorkflowControl>();
		}
	}
}