using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.CrossCutting.Services;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;
using nyom.infra.Data.EntityFramwork.Repositories.Workflow;
using nyom.infra.Factory;

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