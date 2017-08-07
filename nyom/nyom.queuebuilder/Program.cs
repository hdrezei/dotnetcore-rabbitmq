using RabbitMQ.Client;
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
			//var builder = new ConfigurationBuilder()
			//	.AddJsonFile("appsettings.json", false, true);
			//Configuration = builder.Build();

			//_serviceProvider = new ServiceCollection()
			//	.AddDbContext<NyomContext>(o => o.UseSqlServer(Configuration["DefaultConnection"]))
			//	.BuildServiceProvider();

			//var serviceCollection = new ServiceCollection();

			//serviceCollection.AddDbContext<NyomContext>(options =>
			//	options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			//ConfigureServices(serviceCollection);
			
			//var serviceProvider = serviceCollection.BuildServiceProvider();

			//serviceProvider.GetService<NotificationProvider>().Start();
		}

		//private static void ConfigureServices(IServiceCollection serviceCollection)
		//{
			
		//	serviceCollection.AddTransient<INotificationService, NotificationService>();
		//	serviceCollection.AddTransient<INotificationRepository, NotificationRepository>();
		//	serviceCollection.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
		//	serviceCollection.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
			
		//	serviceCollection.AddTransient<NotificationProvider>();
		//}
	}
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };

    //        using (var connection = factory.CreateConnection())
    //        {
    //            using (var channel = connection.CreateModel())
    //            {
    //                channel.QueueDeclare(queue: "CampanhaX", 
    //                                     durable: false,
    //                                     exclusive: false,
    //                                     autoDelete: true,
    //                                     arguments: null);

    //                Console.WriteLine(" [x] Sent {0}", args[0]);

    //                var limit = 0;

    //                while (limit < Convert.ToInt64(args[0]))
    //                {
    //                    string message = "Teste do Helder ";
    //                    message += limit.ToString();

    //                    var body = Encoding.UTF8.GetBytes(message);

    //                    var properties = channel.CreateBasicProperties();
    //                    properties.Persistent = true;

    //                    channel.BasicPublish(exchange: "",
    //                                         routingKey: "CampanhaX",
    //                                         basicProperties: null,
    //                                         body: body);

    //                    limit++;
    //                }
    //            }
    //        }

    //        Console.WriteLine(" Press [enter] to exit.");
    //        Console.ReadLine();
    //    }
    //}
}