using Common;
using Common.Events;
using MassTransit;
using System;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Producer] Starting");
            var busControl = Bus.Factory.CreateUsingRabbitMq(conf =>
            {
                conf.Host(RabbitMqConstants.HostName);
            });
            
            busControl.Start();            

            busControl.Publish(
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
            busControl.Stop();
        }
    }
}
