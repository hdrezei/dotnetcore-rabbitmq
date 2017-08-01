using System;
using System.IO;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace nyom.pushsender
{
	internal class Program
	{
		private static void Main()
		{
			var factory = new ConnectionFactory { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare("hello",
					false,
					false,
					false,
					null);

				var consumer = new EventingBasicConsumer(channel);
				consumer.Received += (model, ea) =>
				{
					var body = ea.Body;
					var message = Encoding.UTF8.GetString(body);
					Console.WriteLine(" [x] Received {0}", message);
					Log(" [x] Received " + message);
				};
				channel.BasicConsume("hello",
					true,
					consumer);

				Console.WriteLine(" Press [enter] to exit.");
				Console.ReadLine();
			}
		}

		public static void Log(string conteudo)
		{
			var folderName = @"c:\log\";
			var pathString = Path.Combine(folderName);
			if (!Directory.Exists(pathString)) Directory.CreateDirectory(pathString);

			var fileName = "log.txt";

			pathString = Path.Combine(pathString, fileName);

			if (!File.Exists(pathString))
			{
				File.Create(pathString);
			}


			var file = File.AppendText(pathString);

			file.WriteLine(conteudo);
			file.Dispose();

			// docker run -d --name c3ae0c4f2db5 -v c:/log:/var/log b40c975edd5e

		}
	}
}