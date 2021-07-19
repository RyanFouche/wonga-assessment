using RabbitMQ.Client;
using RabbitMQ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class Producer : Connection, IProducer
    {
        public Producer(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public void Produce(string message, string routingKey)
        {
            //Exchange settings : 
            var body = Encoding.UTF8.GetBytes(message);

            Channel.BasicPublish(exchange: "wonga",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message}");
        }


    }
}
