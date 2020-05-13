using Common.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    internal class SecondEventConsumer : IConsumer<SecondEvent>
    {
        public Task Consume(ConsumeContext<SecondEvent> context)
        {
            Console.WriteLine("[Consumer] SecondEventConsumer processing");
            return Task.CompletedTask;
        }
    }
}
