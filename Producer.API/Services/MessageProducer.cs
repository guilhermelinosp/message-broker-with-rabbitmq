using Producer.API.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Producer.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "simpleQueue", durable: true, exclusive: false);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish(exchange: "", routingKey: "simpleQueue", null, body);
        }
    }
}
