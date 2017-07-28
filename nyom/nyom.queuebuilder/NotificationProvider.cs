using System;
using System.Text;
using nyom.domain.Notifications;
using RabbitMQ.Client;

namespace nyom.queuebuilder
{
	public class NotificationProvider
    {

	    private readonly INotificationService _notificationService;
		
		public NotificationProvider(INotificationService notificationService)
	    {
		    _notificationService = notificationService;
	    }


	    public void Start()
	    {

		    var dadosNotificacao = _notificationService.All();



			var factory = new ConnectionFactory { HostName = "localhost" };
		    using (var connection = factory.CreateConnection())
		    using (var channel = connection.CreateModel())
		    {
			    channel.QueueDeclare("hello",
				    false,
				    false,
				    false,
				    null);


			    string message = null;
			    foreach (var arg in dadosNotificacao)
				   
					    message = "Enviada a mensagem de numero: " + " " + arg.Contexto;
					    var body = Encoding.UTF8.GetBytes(message);
					    channel.BasicPublish("",
						    "hello",
						    null,
						    body);

				  
		    }

		    Console.WriteLine(" Press [enter] to exit.");
		    Console.ReadLine();
		}
    }
}
