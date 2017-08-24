using System;
using System.Text;
using System.Threading;
using nyom.domain;
using nyom.infra.CrossCutting.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace nyom.pushsender
{
	public class EnviarMensagensPush : IEnviarMensagensPush
	{
		private readonly IAtualizarStatus _atualizarStatus;

		public EnviarMensagensPush(IAtualizarStatus atualizarStatus)
		{
			_atualizarStatus = atualizarStatus;
		}

		public bool Envia(string campanha)
		{
			try
			{

				var factory = new ConnectionFactory {HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest"};
				using (var connection = factory.CreateConnection())
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(queue: campanha, durable: true, exclusive: false, autoDelete: false, arguments: null);

					channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

					Console.WriteLine(" [*] Waiting for messages.");

					var consumer = new EventingBasicConsumer(channel);
					consumer.Received += (model, ea) =>
					{
						var body = ea.Body;
						var message = Encoding.UTF8.GetString(body);
						Console.WriteLine(" [x] Received {0}", message);

						int dots = message.Split('.').Length - 1;
						Thread.Sleep(dots * 1000);

						Console.WriteLine(" [x] Done");

						channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
					};
					channel.BasicConsume(queue: campanha, autoAck: false, consumer: consumer);

					Console.WriteLine(" Press [enter] to exit.");
					Console.ReadLine();
				}
				_atualizarStatus.AtualizarStatusApi(Guid.Parse(campanha), (int)WorkflowStatus.PushSenderCompleted);

				return true;
			}
			catch (Exception e )
			{
				Console.WriteLine(e);
				return false;
			}
		}
	}
}

