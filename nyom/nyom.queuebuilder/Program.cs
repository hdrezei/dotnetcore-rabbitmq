using RabbitMQ.Client;
using System;
using System.Text;

namespace nyom.queuebuilder
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CampanhaX", 
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: true,
                                         arguments: null);

                    Console.WriteLine(" [x] Sent {0}", args[0]);

                    var limit = 0;

                    while (limit < Convert.ToInt64(args[0]))
                    {
                        string message = "Teste do Helder ";
                        message += limit.ToString();

                        var body = Encoding.UTF8.GetBytes(message);

                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;

                        channel.BasicPublish(exchange: "",
                                             routingKey: "CampanhaX",
                                             basicProperties: null,
                                             body: body);

                        limit++;
                    }
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}