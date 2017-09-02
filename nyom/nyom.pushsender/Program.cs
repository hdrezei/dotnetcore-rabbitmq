using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.infra.CrossCutting.Services;

namespace nyom.pushsender
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
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			var serviceProvider = serviceCollection.BuildServiceProvider();
			serviceProvider.GetService<Sender>().Start();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IAtualizarStatus, AtualizarStatus>();
			services.AddScoped<IEnviarMensagensPush, EnviarMensagensPush>();
			services.AddScoped<Sender>();
		}
	}
}