using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Producer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings.json", false)
           .Build();
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfigurationRoot>(configuration)
            .AddTransient(s =>
            {
                return new ConnectionFactory()
                {
                    Uri = new Uri($"{configuration.GetConnectionString("RabbitUri")}")
                };
            })
            .AddSingleton<RabbitMQ.Interfaces.IProducer, RabbitMQ.Producer>()
            .BuildServiceProvider();
            Console.WriteLine("Type 'exit' to quit.");
            while (true)
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                if (name != null)
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