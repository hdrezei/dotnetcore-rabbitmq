using System;
using System.Text;
using nyom.domain.MongoDb.Message;
using RabbitMQ.Client;

namespace nyom.queuebuilder
{
    public class EnfileirarMensagens : IEnfileirarMensagens
    {
	    private readonly IMessageService _messageService;

	    public EnfileirarMensagens(IMessageService messageService)
	    {
		    _messageService = messageService;
	    }

	    public bool EnfileirarMensagensPush(Guid id)
	    {
		    try
		    {
			    var messages = _messageService.FindAll(a => a.CampanhaId.Equals(id.ToString()));

			    if (messages == null)
			    {
				    return false;
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
						    var body = Encoding.UTF8.GetBytes(message.Mensagem);
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
			    return true;
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine(e);
			    return false;
		    }
	    }
	}
}
