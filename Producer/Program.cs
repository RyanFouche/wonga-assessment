using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace Producer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton(s =>
            {
                return new ConnectionFactory()
                {
                    Uri = new Uri($"amqp://{args[0]}:{args[1]}@{args[2]}:{args[3]}/{args[4]}")
                };
            })
            .AddSingleton<RabbitMQ.Interfaces.IProducer, RabbitMQ.Producer>()
            .BuildServiceProvider();
            Console.WriteLine("Type 'exit' to quit.");
            while (true)
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                if(name != null)
                {
                    if (name.ToLower() == "exit")
                    {
                        break;
                    }
                    var producer = serviceProvider.GetService<RabbitMQ.Interfaces.IProducer>();
                    producer.Produce($"Hello my name is, {name}", "messages-process");
                }
            }
            
        }
    }
}