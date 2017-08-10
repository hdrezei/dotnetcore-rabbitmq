using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace nyom.pushsender
{
    class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "rabbit", Port = 5672, UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CampanhaX",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: true,
                                         arguments: null);

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    Console.WriteLine(" [*] Waiting for messages.");
                    Console.WriteLine("Started " + DateTime.Now);

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

                    channel.BasicConsume(queue: "CampanhaX",
                                         autoAck: false,
                                         consumer: consumer);

                    Console.WriteLine("Finished " + DateTime.Now);
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();

                    Thread.Sleep(500000000);
                }
            }
        }
    }
}