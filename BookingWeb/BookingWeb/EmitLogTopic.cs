using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using BookingWeb.Model;
using System.Threading.Tasks;

namespace BookingWeb
{
    public class EmitLogTopic
    {
        public static async Task SendMessage(Tour tour)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "topic_logs",
                                        type: "topic");

                var routingKey = tour.BookCancel;
                var message = "Person " + tour.Name + "With email " + tour.Email + "has " + tour.BookCancel;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "topic_logs",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
            }
        }
    }
}
