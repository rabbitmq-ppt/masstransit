using AdvancedConsumer.Repositories;
using Common.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace AdvancedConsumer.Consumers
{
    internal class PatientCreatedEventConsumer : IConsumer<PatientCreatedEvent>
    {
        private readonly IRepository _repository;

        public PatientCreatedEventConsumer(IRepository repository)
        {
            _repository = repository;
        }
        public Task Consume(ConsumeContext<PatientCreatedEvent> context)
        {
            Console.WriteLine($"Otrzymana wiadomość: {context.Message.Name}");
            _repository.DoSomething();            
            return Task.CompletedTask;
        }
    }
}
