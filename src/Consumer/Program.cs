using Common;
using Consumer.Consumers;
using GreenPipes;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Consumer
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(config => 
            {
                config.Host(RabbitMqConstants.HostName);

                config.ReceiveEndpoint(RabbitMqConstants.PatientCreatedQueue, conf => 
                {
                    //conf.UseMessageRetry(r =>
                    //{
                    //    r.Immediate(3);
                    //});

                    conf.Consumer(() => new PatientCreatedEventConsumer());
                });

                //config.ReceiveEndpoint(RabbitMqConstants.SecondQueue, conf =>
                //{

                //    conf.UseMessageRetry(r =>
                //    {
                //        r.Immediate(3);
                //    });

                //    conf.Consumer(() => new SecondConsumer());
                //});
            });

            await busControl.StartAsync();
            Console.WriteLine("[Consumer] Consuming events. Any key to stop");
            Console.ReadLine();
            await busControl.StopAsync();
        }
    }
}
