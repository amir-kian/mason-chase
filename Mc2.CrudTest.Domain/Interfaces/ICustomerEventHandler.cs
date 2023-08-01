using Mc2.CrudTest.Domain.Events;

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface ICustomerEventHandler : IDomainEventHandler<CustomerCreatedEvent>,
                                              IDomainEventHandler<CustomerUpdatedEvent>,
                                              IDomainEventHandler<CustomerDeletedEvent>
    {
    }
}
