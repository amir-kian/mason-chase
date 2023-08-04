using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace Mc2.CrudTest.Domain.Events
{
    public class CustomerEventHandler : ICustomerEventHandler
    {
        private readonly ILogger<CustomerEventHandler> _logger;
        private readonly IEventRepository<IDomainEvent> _eventRepository;

        public CustomerEventHandler(ILogger<CustomerEventHandler> logger, IEventRepository<IDomainEvent> eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task Handle(CustomerCreatedEvent @event)
        {
            _logger.LogInformation($"Customer {@event.FirstName} {@event.LastName} created with ID {@event.Id}");

            await _eventRepository.AddEvent(@event);
        }

        public async Task Handle(CustomerUpdatedEvent @event)
        {
            _logger.LogInformation($"Customer {@event.FirstName} {@event.LastName} updated with ID {@event.Id}");

            await _eventRepository.AddEvent(@event);
        }

        public async Task Handle(CustomerDeletedEvent @event)
        {
            _logger.LogInformation($"Customer with ID {@event.Id} deleted");

            await _eventRepository.AddEvent(@event);
        }
    }
}
