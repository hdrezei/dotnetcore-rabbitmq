using System;
using RabbitMQ.Client;
using System.Text;
using nyom.domain;
using nyom.domain.MongoDb.Message;
using nyom.infra.CrossCutting.Services;
using Newtonsoft.Json;

namespace nyom.queuebuilder
{
	public class QueueBuilder
    {
        private readonly IMessageService _messageService;
	    private readonly IAtualizarStatus _atualizarStatus;

		public QueueBuilder(IMessageService messageService, IAtualizarStatus atualizarStatus)
		{
			_messageService = messageService;
			_atualizarStatus = atualizarStatus;
		}

        public void Start()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("CAMPANHA"));
            EnfileirarMensagens(Guid.Parse("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060"));
        }

        public void EnfileirarMensagens(Guid id)
        {
            //var messages = _messageService.FindAll(a => a.Status.Equals(WorkflowStatus.QueueBuilder));
	        var messages = _messageService.FindAll(a => a.CampanhaId.Equals(id.ToString()));


            if (messages == null)
            {
                return;
            }

            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
	               
					channel.QueueDeclare(queue: id.ToString(),
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
					
					foreach (var message in messages)
                    {
	                    channel.ExchangeDeclare(exchange: "logs", type: "fanout");
						var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message.Mensagem, Formatting.Indented));
	                    //var body = Encoding.UTF8.GetBytes(message.Mensagem);

						var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;

						channel.BasicPublish(exchange: "",
							routingKey: id.ToString(),
							basicProperties: properties,
							body: body);
	                    Console.WriteLine(" [x] Sent {0}", message);

					}

                }
            }
	        _atualizarStatus.AtualizarStatusApi(id, (int)WorkflowStatus.QueueBuilderCompleted);

        }
    }
}