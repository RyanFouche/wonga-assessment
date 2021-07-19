using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;

namespace Consumer
{
    class Program
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
            .AddSingleton<RabbitMQ.Interfaces.IConsumer, RabbitMQ.Consumer>()
            .BuildServiceProvider();
            while (true)
            {

                serviceProvider.GetService<RabbitMQ.Interfaces.IConsumer>().Consume("message", message =>
                {
                    message = message.Substring(message.LastIndexOf(',') + 1).Trim();
                    Console.WriteLine($"Hello {message}, I am your father!");
                });
            }
        }
    }
}
