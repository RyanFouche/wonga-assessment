using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Interfaces
{
    public interface IProducer
    {
        public void Produce(string message, string routingKey);
    }
}
