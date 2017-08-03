using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nyom.domain.Nyom.Notifications;
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
			EnviarNotificacoesAFila();
		}

		private void EnviarNotificacoesAFila()
		{
			var dadosNotificacao = ObterDadosNotificacao();

			InserirDadosTesteNoBanco(dadosNotificacao);

			dadosNotificacao = ObterDadosNotificacao();

			var factory = new ConnectionFactory { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare("hello",
					false,
					false,
					false,
					null);

				//foreach (var arg in dadosNotificacao)
				//{
				//	var message = arg.Contexto;
				//	var body = Encoding.UTF8.GetBytes(message);
				//	channel.BasicPublish("",
				//		"hello",
				//		null,
				//		body);
				//	//Console.WriteLine(" [x] Sent {0}", message);
				//}

				for (int i = 0; i <= 1000000; i++)
				{
					var message = "Enviando mensagem " + i;
					var body = Encoding.UTF8.GetBytes(message);
					channel.BasicPublish("",
						"hello",
						null,
						body);
					Console.WriteLine(" [x] Sent {0}", message);
				}
			}

			Console.WriteLine(" Press [enter] to exit.");
			Console.ReadLine();
		}

		private void InserirDadosTesteNoBanco(IEnumerable<Notification> dadosNotificacao)
		{
			if (dadosNotificacao.Count() != 0) return;
			for (var i = 0; i < 1000; i++)
			{
				var notification = new Notification()
				{
					NotificationId = Guid.NewGuid(),
					Cadastrado = 1,
					CodigoAplicativo = 1,
					CodigoNotificacao = 1,
					CodigoTemplate = 1,
					Contexto = "Mensagem de número: " + i,
					IdServidor = 1,
					MaxRegistros = 1,
					NomeRobo = "É nois que voa Bruxão",
					Plataforma = 1,
					ThreadName = "Tread_number " + i,
					TokenPush = i.ToString()
				};
				_notificationService.Save(notification);
			}
		}

		private IEnumerable<Notification> ObterDadosNotificacao()
		{
			var dadosNotificacao = _notificationService.All();
			return dadosNotificacao;
		}
	}
}
