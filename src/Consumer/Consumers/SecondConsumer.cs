using Common.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    internal class SecondConsumer : IConsumer<SecondEvent>
    {
        public async Task Consume(ConsumeContext<SecondEvent> context)
        {
            await Console.Out.WriteLineAsync($"SecondConsumer processed: {context.Message.Message}").ConfigureAwait(false);            
        }
    }
}
