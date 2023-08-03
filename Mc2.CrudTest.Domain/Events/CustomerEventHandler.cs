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

        public void Handle(CustomerCreatedEvent @event)
        {
            _logger.LogInformation($"Customer {@event.FirstName} {@event.LastName} created with ID {@event.Id}");

            _eventRepository.AddEvent(@event);
        }

        public void Handle(CustomerUpdatedEvent @event)
        {
            _logger.LogInformation($"Customer {@event.FirstName} {@event.LastName} updated with ID {@event.Id}");

            _eventRepository.AddEvent(@event);
        }

        public void Handle(CustomerDeletedEvent @event)
        {
            _logger.LogInformation($"Customer with ID {@event.Id} deleted");

            _eventRepository.AddEvent(@event);
        }
    }
}
