using AdvancedConsumer.Consumers;
using AdvancedConsumer.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Common;
using GreenPipes;
using MassTransit;
using System;

namespace AdvancedConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IRepository>().ImplementedBy<PatientRepository>().LifeStyle.Transient);


            container.AddMassTransit(c => 
            {
                c.AddConsumer<PatientCreatedEventConsumer>(config => 
                {
                    config.UseMessageRetry(rc => rc.Immediate(5));
                    config.UseInMemoryOutbox();
                });

                c.AddBus((kernel) => Bus.Factory.CreateUsingRabbitMq(busConfig => 
                {
                    busConfig.Host(RabbitMqConstants.HostName);

                    busConfig.ReceiveEndpoint(RabbitMqConstants.PatientCreatedQueue, receiverConfig => receiverConfig.ConfigureConsumer(container, typeof(PatientCreatedEventConsumer)));
                }));
                
            });

            Console.WriteLine("Hello World!");
            container.Resolve<IBusControl>().Start();
            Console.ReadLine();
            container.Resolve<IBusControl>().Stop();
        }
    }
}
