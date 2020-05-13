using AdvancedConsumer.Consumers;
using AdvancedConsumer.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common;
using GreenPipes;
using MassTransit;

namespace AdvancedConsumer.IoC
{
    internal class ConsumerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
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
        }
    }
}
