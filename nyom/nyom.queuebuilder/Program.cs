using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;
using nyom.domain.Notifications;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;

namespace nyom.queuebuilder
{
	internal class Program
	{
		public static IConfigurationRoot Configuration { get; set; }
		private static IServiceProvider _serviceProvider;

		private static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true);
			Configuration = builder.Build();

			_serviceProvider = new ServiceCollection()
				.AddDbContext<NyomContext>(o => o.UseSqlServer(Configuration["DefaultConnection"]))
				.BuildServiceProvider();

			var serviceCollection = new ServiceCollection();

			serviceCollection.AddDbContext<NyomContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			ConfigureServices(serviceCollection);
			
			var serviceProvider = serviceCollection.BuildServiceProvider();

			serviceProvider.GetService<NotificationProvider>().Start();
		}

		private static void ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<INotificationService, NotificationService>();
			serviceCollection.AddTransient<INotificationRepository, NotificationRepository>();
			serviceCollection.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			serviceCollection.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
			serviceCollection.AddTransient<NotificationProvider>();
		}
	}
}