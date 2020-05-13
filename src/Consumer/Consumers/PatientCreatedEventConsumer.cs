using Common.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    internal class PatientCreatedEventConsumer : IConsumer<PatientCreatedEvent>
    {
        public async Task Consume(ConsumeContext<PatientCreatedEvent> context)
        {
            Console.WriteLine($"Otrzymana wiadomość {context.CorrelationId}: {context.Message.Name}");            
            await context.Publish<SecondEvent>(new SecondEvent
            {
                Message = "Second event wygenerowany w consumerze PatientCreated"
            }).ConfigureAwait(false);
            
            Console.WriteLine($"Tu dlasze akcje consumera");

        }
    }
}
