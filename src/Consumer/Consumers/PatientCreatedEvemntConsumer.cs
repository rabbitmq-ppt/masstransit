using Common.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    internal class PatientCreatedEvemntConsumer : IConsumer<PatientCreatedEvent>
    {
        public async Task Consume(ConsumeContext<PatientCreatedEvent> context)
        {
            Console.WriteLine($"[Consumer] Processing event PatientCreatedEvent: Etap1");
            await context.Publish(new SecondEvent());
            //throw new NotImplementedException();
            Console.WriteLine($"[Consumer] Processing event PatientCreatedEvent: Etap2");            
        }
    }
}
