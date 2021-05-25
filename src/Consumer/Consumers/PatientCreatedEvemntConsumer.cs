using Common.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    internal class PatientCreatedEvemntConsumer : IConsumer<PatientCreatedEvent>
    {
        public Task Consume(ConsumeContext<PatientCreatedEvent> context)
        {
            Console.WriteLine($"[Consumer] Processing event PatientCreatedEvent: Etap1");
            //await context.Publish(new SecondEvent());            
            return Task.CompletedTask;
        }
    }
}
