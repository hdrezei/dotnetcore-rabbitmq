using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;
using nyom.domain.Nyom.Notifications;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories;

namespace nyom.queuebuilder
{
	internal class Program
	{
		public static IConfigurationRoot Configuration { get; set; }
		private static ServiceCollection _serviceProvider;

		private static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, true);
			Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();

			ConfigureServices(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();

			serviceProvider.GetService<NotificationProvider>().Start();


			_serviceProvider = new ServiceCollection();

			_serviceProvider.AddDbContext<NyomContext>(o => o.UseSqlServer(Configuration["DefaultConnection"]))
				.BuildServiceProvider();

			_serviceProvider.AddDbContext<Nyom2Context>(o => o.UseSqlServer(Configuration["DefaultConnection2"]))
				.BuildServiceProvider();


			serviceCollection.AddDbContext<NyomContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			serviceCollection.AddDbContext<Nyom2Context>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection2")));
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