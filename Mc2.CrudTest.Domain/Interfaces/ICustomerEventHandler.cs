using Mc2.CrudTest.Domain.Events;

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface ICustomerEventHandler
    {
        Task Handle(CustomerCreatedEvent @event);
        Task Handle(CustomerUpdatedEvent @event);
        Task Handle(CustomerDeletedEvent @event);
    }
}
