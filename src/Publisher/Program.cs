using Common;
using Common.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Publisher
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("[Producer] Starting");
            var busControl = Bus.Factory.CreateUsingRabbitMq(conf =>
            {
                conf.Host(RabbitMqConstants.HostName);
            });

            await busControl.StartAsync();

            await busControl.Publish(
                new PatientCreatedEvent
                {
                    Id = 1,
                    Name = "Piotr"
                },
                context =>
                {
                    context.CorrelationId = Guid.NewGuid();                    
                });

            Console.WriteLine($"[Producer] Wysłał wiadomość");
            Console.ReadLine();
            await busControl.StopAsync();
        }
    }
}
