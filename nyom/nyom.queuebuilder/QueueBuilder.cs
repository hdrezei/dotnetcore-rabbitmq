using System;
using nyom.domain;
using nyom.domain.Message;
using RabbitMQ.Client;
using System.Text;
using nyom.domain.MongoDb.Message;
using Newtonsoft.Json;

namespace nyom.queuebuilder
{
    public class QueueBuilder
    {
        private readonly IMessageService _messageService;

        public QueueBuilder(IMessageService messageService)
        {
	        _messageService = messageService;
        }

        public void Start()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("CAMPANHA"));
            EnfileirarMensagens(Guid.Parse("cc7dd79a-bbfa-4e17-b8e7-27d9e4b30dbb"));
        }

        public void EnfileirarMensagens(Guid id)
        {
            var messages = _messageService.FindAll(a => a.Status.Equals(WorkflowStatus.QueueBuilder));

            if (messages == null)
            {
                return;
            }

            var factory = new ConnectionFactory() { HostName = "rabbit", Port = 5672, UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
	               
					channel.QueueDeclare(queue: id.ToString(),
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: true,
                                         arguments: null);
					
					foreach (var message in messages)
                    {
	                    channel.ExchangeDeclare(exchange: "logs", type: "fanout");
						var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, Formatting.Indented));

                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;

                        channel.BasicPublish(exchange: "logs",
                                             routingKey: id.ToString(),
                                             basicProperties: null,
                                             body: body);
	                   
					}
                }
            }
        }
    }
}