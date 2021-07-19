using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.IO;

namespace Consumer
{
    class Program
    {
        private static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

            var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfigurationRoot>(configuration)
            .AddSingleton(s =>
            {
                return new ConnectionFactory()
                {
                    Uri = new Uri($"{configuration.GetConnectionString("RabbitUri")}")
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
