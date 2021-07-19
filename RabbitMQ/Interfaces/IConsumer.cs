using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Interfaces
{
    public interface IConsumer
    {
        public void Consume(string queue, Action<string> received);
    }
}
