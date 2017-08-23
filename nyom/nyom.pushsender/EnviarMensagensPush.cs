using System;
using System.Text;
using System.Threading;

using nyom.infra.CrossCutting.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace nyom.pushsender
{
	public class EnviarMensagensPush : IEnviarMensagensPush
	{
		
		public bool Envia(string campanha)
		{
			try
			{
				var factory = new ConnectionFactory {HostName = "rabbit", Port = 5672, UserName = "guest", Password = "guest"};
				using (var connection = factory.CreateConnection())
				{
					using (var channel = connection.CreateModel())
					{
						channel.ExchangeDeclare("amg.rabbitmq.trace", "fanout");
						channel.QueueBind(exchange: "amg.rabbitmq.trace", queue: campanha, routingKey: "#");
						channel.QueueDeclare(campanha,
							false,
							false,
							true,
							null);

						channel.BasicQos(0, 1, false);

						Console.WriteLine(" [*] Waiting for messages.");
						Console.WriteLine("Started " + DateTime.Now);

						var consumer = new EventingBasicConsumer(channel);

						consumer.Received += (model, ea) =>
						{
							var body = ea.Body;
							var message = Encoding.UTF8.GetString(body);
							Console.WriteLine(" [x] Received {0}", message);
							var dots = message.Split('.').Length - 1;
							Thread.Sleep(dots * 1000);
							Console.WriteLine(" [x] Done");
							channel.BasicAck(ea.DeliveryTag, false);
						};

						channel.BasicConsume(campanha,
							false,
							consumer);

						Console.WriteLine("Finished " + DateTime.Now);
						Console.WriteLine(" Press [enter] to exit.");
						Console.ReadLine();

						Thread.Sleep(500000000);
					}
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}

