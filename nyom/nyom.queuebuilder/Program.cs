using System;
using System.Text;
using nyom.domain.Notifications;
using RabbitMQ.Client;

namespace nyom.queuebuilder
{
	internal class Program
	{
		//public static IConfigurationRoot Configuration { get; set; }
		//private static IServiceProvider _serviceProvider;

		
		private static INotificationService _notificationService;

		public Program(INotificationService notificationService)
		{
			
			_notificationService = notificationService;
		}

		private static void Main(string[] args)
		{
			////var builder = new ConfigurationBuilder()
			////	.AddJsonFile("appsettings.json", false, true);
			////Configuration = builder.Build();


			////_serviceProvider = new ServiceCollection()
			////	.AddDbContext<NyomContext>(o => o.UseSqlServer(Configuration["DefaultConnection"]))
			////	.BuildServiceProvider();

			var dadosNotificacao = _notificationService.Find(a => a.CodigoNotificacao.Equals(0));

			var factory = new ConnectionFactory {HostName = "localhost"};
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare("hello",
					false,
					false,
					false,
					null);

				
				foreach (var arg in args)
					for (var i = 0; i <= Convert.ToInt32(arg); i++)
					{
						var message = "Enviada a mensagem de numero: " + " " + i;
						var body = Encoding.UTF8.GetBytes(message);
						channel.BasicPublish("",
							"hello",
							null,
							body);
						
					}
			}

			Console.WriteLine(" Press [enter] to exit.");
			Console.ReadLine();
		}
	}
}