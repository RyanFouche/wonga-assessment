using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class Connection :  IDisposable
    {
        private IConnection _connection;
        private readonly ConnectionFactory _connectionFactory;
        public static IModel Channel { get; private set; }
        public Connection(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            Connect();
        }
        public void Connect()
        {
            //check if connection exists
            if(_connection == null)
            {
                _connection = _connectionFactory.CreateConnection();
            }
            //if connection does not exist  declare exchange and queues
            if (Channel == null)
            {
                Channel = _connection.CreateModel();
                Channel.ExchangeDeclare("wonga", "direct", true);

                Channel.QueueDeclare(queue: "message",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                Channel.QueueBind("message", "wonga", "messages-process");
            }
        }
        public void Dispose()
        {
            try
            {
                Channel.Close();
                Channel.Dispose();
                _connection.Close();
                _connection.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
